import numpy as np
import cv2
import os.path

cmdfile = "config.txt"
filename2d = "map2d.txt"
filename3d = "map2d.txt"

# region file and array init
if os.path.isfile(filename2d): #check existing 2dmap file
    pic = np.genfromtxt(dtype=np.int8)
else:
    pic = np.zeros((1024, 1024, 3), dtype=np.int8)

if os.path.isfile(filename2d):
    zpic = np.genfromtxt(dtype=np.float64) #check existing 3dmap file
else:
    zpic = np.zeros((1024, 1024), dtype=np.float64)

if not os.path.isfile(cmdfile): #check existing of cmdfile
    sys.quit()

cmd = open(cmdfile).readline() #check is cmd enaged
if cmd == "":
    sys.quit()

# endregion

arr=list(cmd.split(" "))

#region generation functions init

#endregion

#region cmd reaction
if arr[0]=="cylinder":
    print("cylinder generation")

elif arr[0]=="cone":
    print("cone generation")

elif arr[0]=="sphere":
    print("sphere generation")

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
