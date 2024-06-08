"""Wagner Domingos;Brazília;x;71,97;72,28
Ivan Cihan;Fehéroroszország;76,13;77,43;73,48;x;77,79;76,34"""
class Versenyzo:
    def __init__(self,Nev,Orszag,Dobasok):
        self.Nev=Nev
        self.Orszag=Orszag
        self.Dobasok=Dobasok
lista=[]
db=0
f=open("kalapacsvetes2016.txt","r",encoding="utf-8")
for sor in f:
    sz=sor.strip().split(';')
    dobasok=sz[2:]
    a=Versenyzo(sz[0],sz[1],dobasok)
    lista.append(a)
    db+=1
#print(lista[1].Nev," ",lista[1].Orszag," ",lista[1].Dobasok)#Nev,Orszag,Dobasok
print("5. feladat:Döntőbe jutott versenyzők száma: ",db)
dontosokszama=0
for a in lista:#Nev,Orszag,Dobasok
    if len(a.Dobasok)>3:
        dontosokszama+=1
print("6. feladat:A 3. dobás után ",dontosokszama," versenyző folytathatta a döntőt ")
#A döntőt folytató versenyzők érvényes, sikertelen és legjobb dobásai 
print("7.feladat: Statisztika (név;érvényes dobás;sikertelen dobás;legjobb dobás")
stat={}
for a in lista:#Nev,Orszag,Dobasok
    ervenyes=0
    ervenytelen=0
    legjobbdobas=None
    if len(a.Dobasok)>3:
        for i in range(len(a.Dobasok)):#végimegyünk a dobásokon
            if a.Dobasok[i]!="x":
                try:
                    dobas=float(a.Dobasok[i].replace(',','.'))
                    ervenyes+=1
                    if legjobbdobas is None or dobas>legjobbdobas:
                        legjobbdobas=dobas
                except ValueError:
                    ervenytelen+=1
            else:
                ervenytelen+=1
        if legjobbdobas is None:
            legjobbdobas=0
        print("\t",a.Nev,";",ervenyes,";",ervenytelen,";",legjobbdobas)
        stat[a.Nev]=legjobbdobas
#print(stat)
print("Végeredmény")
sorbarendezett_lista=sorted(stat.items(),key=lambda item:item[1],reverse=True)
i=1
for nev,dobas in sorbarendezett_lista:
    print("\t",i,". helyezett: ",nev,": ",dobas," m")
    i+=1
i=1
for nev,dobas in sorbarendezett_lista:
    if nev=="Pars Krisztián":
        print("8. feladat: A magyar versenyző ",nev," ",i,". lett")
    i+=1
#9.Készítsen kalapacsvetes2016inch.txt néven szöveges állományt, amely csak annyiban különbözzön a forrás fájltól, 
#       hogy a dobások távolságát centiméter helyett hüvelyk (coll) mértékegységben, három tizedes jegyre kerekítve tartalmazza! 1coll=2,54cm!
fajl=open("kalapacsvetes2016inch.txt","w",encoding="utf-8")
for a in lista:#Nev,Orszag,Dobasok
    sz=a.Nev+";"+a.Orszag+";"
    for i in range(len(a.Dobasok)):
        try:
            dobas=float(a.Dobasok[i].replace(',','.'))
            dobas=round(dobas*100/2.54,3)# három tizedes jegyre kerekítve
            if i<len(a.Dobasok)-1:#az utolsó adat után nem kell ;
                sz+=str(dobas)+";"
            else:
                sz+=str(dobas)#az utolsó adat után ne írjon ;-t
        except ValueError:
            if i<len(a.Dobasok)-1:#az utolsó adat után nem kell ;
                sz+="x;"
            else:
                sz+="x"#az utolsó adat után ne írjon ;-t
    fajl.write(sz+"\n")
fajl.close()