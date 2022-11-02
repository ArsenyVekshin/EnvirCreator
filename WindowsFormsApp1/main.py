import numpy as np
import math as m

filename2d = "map2d.txt"
filename3d = "map3d.txt"
filenamestl = "Envir.stl"
filenameinp = "input.txt"
picParam = [800, 600]

pic = np.zeros(shape=(picParam[0], picParam[1], 3), dtype=np.uint8)
picz = np.zeros(shape=(picParam[0], picParam[1]), dtype=int)
figures = np.genfromtxt(filenameinp, dtype=np.string)

# region fig_types
circ = {
    "flag": "circle",
    "colour": [0, 0, 0],
    "R": 0,
    "center": [0, 0, 0]
}

cone = {
    "flag": "cone",
    "colour": [0, 0, 0],
    "H": 0,
    "R": 0,
    "center": [0, 0, 0]
}

cyl = {
    "flag": "cylinder",
    "colour": [0, 0, 0],
    "H": 0,
    "R": 0,
    "center": [0, 0, 0]
}

prism = {
    "flag": "prism",
    "colour": [0, 0, 0],
    "H": 0,
    "base": []
}

pyr = {
    "flag": "pyramid",
    "colour": [0, 0, 0],
    "H": 0,
    "base": []
}


# endregion

# region Array_generator
def Get_len(p1,p2):
    return m.sqrt((p1[0]-p2[0])**2 + (p1[1]-p2[1])**2)

def Draw_circle(center=[0,0,0], R=1, clr =[255,255,255]):
    """
    :param center: [x,y,z]
    :param R: circle radius
    :param clr: [r,g,b]
    :return: None
    """
    x_ax = [center[0] - R - 1, center[0] + R + 1]
    y_ax = [center[1] - R - 1, center[1] + R + 1]
    R *= R
    flag=True
    if pic[center[0], center[1], center[2]]==clr: flag=False
    for x in x_ax:
        for y in y_ax:
            if (center[0] - x) ** 2 + (center[1] - y) ** 2 <= R:
                if flag: pic[y][x] = clr
                picz[y][x] = center[2]

def Draw_Nangle(basis=[], h=0):
    arr=basis.copy()
    arr1=[arr[0]]
    mn=[arr[0]]
    while len(arr)!=0:
# endregion

def Gen_figure(arr):
    if arr[0] == "circle": return
