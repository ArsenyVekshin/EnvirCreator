import numpy as np
import cv2
import os.path
import math as m

cmdfile = "config.txt"
imgfile = "view2d.jpg"
filename2d = "map2d.txt"
filename3d = "map3d.txt"
picX, picY = 512, 512

# region file and array init
#if os.path.isfile(filename2d): #check existing 2dmap file
#    pic = np.genfromtxt(filename2d,dtype=np.uint8)
#else:
pic = np.zeros((picY, picX, 3), dtype=np.uint8)

#if os.path.isfile(filename3d):
#    zpic = np.genfromtxt(filename3d) #check existing 3dmap file
#else:
zpic = np.zeros((picY, picX), dtype=int)

if not os.path.isfile(cmdfile): #check existing of cmdfile
    sys.quit()
print("prev: ok")

# endregion

#region generation functions init
def Draw_circle(clr, c_point, R, flag=0):
    x_min, x_max = c_point[0]-R, c_point[0]+1 + R
    y_min, y_max = c_point[1]-R, c_point[1]+1 + R

    for y in range(y_min, y_max):
        for x in range(x_min, x_max):
            if(((x-c_point[0])**2 + (y-c_point[1])**2) <= R**2):
                if(pic[y][x][0]==clr[0] and pic[y][x][1]==clr[1] and pic[y][x][2]==clr[2]): continue
                pic[y][x]=clr
                zpic[y][x]=int(c_point[2])

def Draw_cone(arr):
    #cone r g b x0 y0 z0 R H
    clr = arr[1:4]
    clr.reverse()
    c_point = arr[4:7]
    R, H = arr[7], arr[8]
    dh = (H - c_point[2])/R #шаг по высоте на изменении радиуса на 1
    R=1
    #Draw_circle([250,250,250], c_point, R) #создаем "дырку"

    c_point[2]+=H
    for i in range(arr[7]):
        R+=1
        c_point[2]-=dh
        Draw_circle(clr, c_point, int(R))

def Draw_cylinder(arr):
    #cylinder r g b x0 y0 z0 R H
    clr = arr[1:4]
    clr.reverse()
    c_point = arr[4:7]

    H, R = arr[7], arr[8]
    c_point[2] += H

    Draw_circle(clr, c_point, R, 1)

def Draw_sphere(arr):
    #sphere r g b x0 y0 z0 R
    clr = arr[1:4]
    clr.reverse()
    c_point = arr[4:7]
    R = arr[7]

    c_point[2]+=int(R/2)

    x_min, x_max = c_point[0] - R, c_point[0] + R+1
    y_min, y_max = c_point[1] - R, c_point[1] + R+1

    for y in range(y_min, y_max):
        for x in range(x_min, x_max):
            if (((x - c_point[0]) ** 2 + (y - c_point[1]) ** 2) <= R**2):
                pic[y][x] = clr
                zpic[y][x] = int(m.sqrt(R**2 - (x - c_point[0]) ** 2 - (y - c_point[1]) ** 2))



#endregion

#region cmd reaction
f = open(cmdfile)

for s in f:
    if(s==""): continue
    arr=list(s.split(" "))
    print(arr)
    for i in range(1,len(arr)): arr[i]=int(arr[i])

    if arr[0]=="cylinder":
        print("step1")
        Draw_cylinder(arr)
        print("step2")
    elif arr[0]=="cone":
        Draw_cone(arr)

    elif arr[0]=="sphere":
        Draw_sphere(arr)

    elif arr[0]=="pyramid":
        print("pyramid generation")

    elif arr[0] == "prism":
        print("prism generation")

    elif arr[0] == "2dpic":
        print("2dpic visualise")

    elif arr[0] == "3dpic":
        print("3dpic visualise")
#endregion
cv2.imwrite(imgfile, pic)
#region save_data
def save2files():
    f1 = open(filename2d, "w")
    f2 = open(filename3d, "w")
    for y in range(picY):
        for x in range(picX):
            f1.write(str(pic[y][x][0]) + " ")
            f1.write(str(pic[y][x][1]) + " ")
            f1.write(str(pic[y][x][2]) + " ")
            f2.write(str(zpic[y][x]) + " ")
        f1.write("\n")
        f2.write("\n")
    f1.close()
    f2.close()
save2files()
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
