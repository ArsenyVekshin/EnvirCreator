import numpy as np
import cv2
import os.path
import math as m
#import plotly.graph_objects as go
import matplotlib.pyplot as plt
import time as t
import threading

cmdfile = "config.txt"
imgfile = "view2d.jpg"
filename2d = "map2d.txt"
filename3d = "map3d.txt"
picX, picY = 512, 512

#cylinder 200 0 0 200 200 0 20 100
#cone 200 0 200 300 300 0 50 500
#sphere 200 200 200 100 100 100 75
#prism 100 100 100 20 20 1 50 20 1 100 40 1 80 120 1 20 80 1    50


#region file and array init
if os.path.isfile(filename2d): #check existing 2dmap file
    pic = np.genfromtxt(filename2d,  dtype=np.uint8).reshape((picY, picX, 3))
else:
    pic = np.zeros((picY, picX, 3), dtype=np.uint8)

if os.path.isfile(filename3d):
    zpic = np.genfromtxt(filename3d, dtype=int).reshape((picY, picX)) #check existing 3dmap file
else:
    zpic = np.zeros((picY, picX), dtype=int)

if not os.path.isfile(cmdfile): #check existing of cmdfile
    sys.quit()
print("prev: ok")

# endregion

#region generation functions init
def Create_contour(points):
    contour = []
    for i in range(len(points)):
        A = points[i]
        if (i == len(points) - 1):
            B = points[0]
        else:
            B = points[i + 1]

        if (A[0] >= B[0]): A, B = B, A
        k = (B[1] - A[1]) / ((B[0] - A[0]) if (B[0] - A[0]) != 0 else 1)
        for j in range(B[0] - A[0]):
            p1 = [A[0] + j, int(A[1] + j * k)]
            if (p1 not in contour): contour.append([A[0] + j, int(A[1] + j * k)])

        if (A[1] >= B[1]): A, B = B, A
        k = (B[0] - A[0]) / ((B[1] - A[1]) if (B[1] - A[1]) != 0 else 1)
        for j in range(B[1] - A[1]):
            p1 = [int(A[0] + j * k), A[1] + j]
            if (p1 not in contour): contour.append([int(A[0] + j * k), A[1] + j])
    return contour

def Draw_circle(clr, c_point, R):
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

def Draw_contour(contour, clr):
    clr.reverse()
    for a in contour:
        pic[a[1]][a[0]]=clr

def Draw_plane(contour, clr, h):
    clr.reverse()
    x_ax = [x for x, _ in contour]
    y_ax = [y for _, y in contour]
    arr1=[]
    for i in x_ax:
        if(i not in arr1): arr1.append(i)
    x_ax=arr1

    arr1 = []
    for i in y_ax:
        if (i not in arr1): arr1.append(i)
    y_ax = arr1

    out=[]
    for X in x_ax[1:-1]:
        size=[0, picY]
        for p in contour:
            if(p[0]==X):
                size=[max(size[0], p[1]), min(size[1], p[1])]
        for Y in range(size[1], size[0]+1):
            if (pic[Y][X][0] == clr[0] and pic[Y][X][1] == clr[1] and pic[Y][X][2] == clr[2]): continue
            pic[Y][X] = clr
            zpic[Y][X] = h

    for Y in y_ax[1:-1]:
        size=[0,picX]
        for p in contour:
            if(p[1]==Y):
                size=[max(size[0], p[0]), min(size[1], p[0])]
        for X in range(size[1], size[0]+1):
            if (pic[Y][X][0] == clr[0] and pic[Y][X][1] == clr[1] and pic[Y][X][2] == clr[2]): continue
            pic[Y][X] = clr
            zpic[Y][X] = h

def Draw_prism(arr):
    clr = arr[1:4]
    clr.reverse()
    points=[]
    for i in range(4, len(arr)-1, 3):
        points.append([arr[i],arr[i+1],arr[i+2]])
    H=arr[-1]
    #y=kx + l
    Draw_plane(Create_contour(points), clr, arr[-1])

#endregion

#region visualise functions init
#def view3d():
#    fig = go.Figure(data=[go.Mesh3d(x=picX,
#                                    y=picY,
#                                    z=800,
#                                    opacity=0.5,
#                                    color='rgba(244,22,100,0.6)'
#                                    )])

def view3d():
    t1=t.time()
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')
    print("point1: ok")
    c=np.zeros((3, picX*picY), dtype=int)
    clr=np.zeros((picX*picY, 4), dtype=float)

    for y in range(picY):
        #print(y)
        for x in range(picX):
            c[0][y*picX + x] = x
            c[1][y * picX + x] = y
            c[2][y * picX + x] = zpic[y][x]
            clr[y * picX + x] =[pic[y][x][0]/255, pic[y][x][1]/255, pic[y][x][2]/255, 1]
            #ax.scatter3D(x,y,zpic[y][x])
            #ax.scatter(x,y,zpic[y][x])
    print("point2: ok")
    print("3d gen time1: ", t.time() - t1)
    t1 = t.time()
    ax.scatter3D(c[0], c[1], c[2],edgecolors=clr)
    print("3d gen time2: ", t.time() - t1)
    t1=t.time()
    fig.show()
    #fig.savefig("fig1.png")
    print("3d save time: ", t.time() - t1)
#endregion

#region cmd reaction
f = open(cmdfile)

for s in f:
    s=s[:-1]
    if(s==""): continue
    arr=list(s.split(" "))
    arr1=[arr[0]]
    for i in range(1,len(arr)):
        if(arr[i]!=""): arr1.append(int(arr[i]))
    arr=arr1
    print(arr)

    if arr[0]=="cylinder":
        Draw_cylinder(arr)

    elif arr[0]=="cone":
        Draw_cone(arr)

    elif arr[0]=="sphere":
        Draw_sphere(arr)

    elif arr[0]=="pyramid":
        continue

    elif arr[0] == "prism":
        Draw_prism(arr)

    elif arr[0] == "2dpic":
        cv2.imwrite(imgfile, pic)

    elif arr[0] == "3dpic":
        view3d()

#endregion

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
