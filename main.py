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

file= open("config11.txt", "w")
file.write("TEST")
file.close()