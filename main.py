import numpy as np
import cv2
import os.path
import math as m

cmdfile = "config.txt"
filename2d = "map2d.txt"
filename3d = "map2d.txt"

# region file and array init
if os.path.isfile(filename2d): #check existing 2dmap file
    pic = np.genfromtxt(filename2d,dtype=np.int8)
else:
    pic = np.zeros((1024, 1024, 3), dtype=np.int8)

if os.path.isfile(filename3d):
    zpic = np.genfromtxt(filename3d) #check existing 3dmap file
else:
    zpic = np.zeros((1024, 1024))

if not os.path.isfile(cmdfile): #check existing of cmdfile
    sys.quit()

cmd = open(cmdfile).readline() #check is cmd enaged
if cmd == "":
    sys.quit()

# endregion
arr=list(cmd.split(" "))
arr=[arr[0], int(arr[1]), int(arr[2]), int(arr[3]), int(arr[4]), int(arr[5]), int(arr[6]), int(arr[7]), int(arr[8])]
#region generation functions init
def Draw_circle(clr, c_point, R, flag=0):
    x_min, x_max = c_point[0]-R, c_point[0]+R+1
    y_min, y_max = c_point[1]-R, c_point[1]+R+1

    for y in range(y_min, y_max):
        for x in range(x_min, x_max):
            if(m.sqrt((x-c_point[0])**2 + (y-c_point[1])**2) <= R):
                if(flag==1 or pic[y][x]==[0,0,0] or clr==[0,0,0]):
                    pic[y][x]=clr
                    zpic[y][x]=int(c_point[2])

def Draw_cone(arr):
    #cone r g b x0 y0 z0 R H
    clr = arr[1:3]
    c_point = arr[4:6]
    H, R = arr[7], arr[8]
    dh = (H - c_point[2])/R #шаг по высоте на изменении радиуса на 1

    Draw_circle([0,0,0], c_point, R) #создаем "дырку"

    c_point[2]+=H
    for i in range(arr[8]):
        R-=1
        c_point[2]-=dh
        Draw_circle(clr, c_point, int(R))

def Draw_cylinder(arr):
    #cylinder r g b x0 y0 z0 R H
    clr = arr[1:3]
    c_point = arr[4:6]
    H, R = arr[7], arr[8]
    c_point[2] += H

    Draw_circle(clr, c_point, R, 1)

def Draw_sphere(arr):
    #sphere r g b x0 y0 z0 R
    clr = arr[1:3]
    c_point = arr[4:6]
    R = arr[7]
    Draw_circle([0,0,0], c_point, R) #создаем "дырку"

    c_point[2]+=int(R/2)

    x_min, x_max = c_point[0] - R, c_point[0] + R + 1
    y_min, y_max = c_point[1] - R, c_point[1] + R + 1

    for y in range(y_min, y_max):
        for x in range(x_min, x_max):
            if (m.sqrt((x - c_point[0]) ** 2 + (y - c_point[1]) ** 2) <= R):
                pic[y][x] = clr
                zpic[y][x] = int(m.sqrt(R**2 - (x - c_point[0]) ** 2 - (y - c_point[1]) ** 2))



#endregion

#region cmd reaction
if arr[0]=="cylinder":
    Draw_cylinder(arr)

elif arr[0]=="cone":
    Draw_cone(arr)

elif arr[0]=="sphere":
    Draw_sphere(arr)

elif arr[0]=="pyramid":
    print("pyramid generation")

elif arr[0] == "pyramid":
    print("pyramid generation")

elif arr[0] == "2dpic":
    print("2dpic visualise")

elif arr[0] == "3dpic":
    print("3dpic visualise")
#endregion

#region save_data
np.save(filename2d, pic)
np.save(filename3d, zpic)
#endregion

"""
Словарь входных данных для config.txt

фигуры:
	cylinder r g b x0 y0 z0 R H
	cone r g b x0 y0 z0 R H
	sphere r g b x0 y0 z0 R

	pyramid r g b x0 y0 z0 ... xn yn zn H
	prism r g b x0 y0 z0 ... xn yn zn H

Визуализация: 
		2dpic
		3dpic


Примечание:
Все команды будут приходить по одиночке и запускаться в разных ядрах проца
Размеры изображения 600 х 800
на выходе 2 массива(желательно сохранять чреез numpy, тк потом им же прога и будет их импортить)
Названия файлов: 
		map2d.txt(картинка 2д)
		map3d.txt(карта высот)				
"""
