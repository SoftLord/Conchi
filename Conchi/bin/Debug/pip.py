import subprocess

#output = str(subprocess.run("pip list"))
output = str(subprocess.check_output("pip list"))
output = output.replace("b'Package           Version", "")
output = output.replace("'", "")
output = output.replace("----------------- ---------", "")
output = output.replace("\\r\\n\\r\\n", "")
output = output.replace("\\r\\n", " ")
#eliminaciones de espacios
output = output.replace("          ", "")
output = output.replace("         ", "")
output = output.replace("        ", "")
output = output.replace("       ", "")
output = output.replace("      ", "")
output = output.replace("     ", "")
output = output.replace("    ", "")
output = output.replace("   ", "")
output = output.replace("  ", "")
output = output.replace(" ", "\n")
#eliminaciones de numeros
for i in range (9):
    output = output.replace(str(i), "")
output = output.replace(".", "")


librerias_instaladas = open("librerias_python.txt", "w+")
librerias_instaladas.write(output)
librerias_instaladas.close()