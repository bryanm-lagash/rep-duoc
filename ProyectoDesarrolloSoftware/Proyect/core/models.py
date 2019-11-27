from django.db import models

# Create your models here.
class Empresa(models.Model):
    nombre = models.CharField(max_length=40)
    ubicacion = models.CharField(max_length=30)
    def __str__(self):
        return self.nombre

class Cliente(models.Model):
    rut = models.CharField(max_length=11,unique=True)
    nombres = models.CharField(max_length=50)
    apellidos = models.CharField(max_length=50)
    genero = models.CharField(max_length=10)
    fechanamiento = models.DateField(verbose_name="Fecha de Nacimiento")
    direccion = models.CharField(max_length=40)
    telefono = models.CharField(max_length=15)
    email = models.CharField(max_length=35)
    empresa = models.ForeignKey(Empresa, on_delete=models.CASCADE)  
    imagen = models.ImageField(upload_to="clientes",null=True)   

    def __str__(self):
        return self.rut

    class Meta:
        #db_table = ''
        #managed = True
        verbose_name = 'Cliente'
        verbose_name_plural = 'Clientes' 