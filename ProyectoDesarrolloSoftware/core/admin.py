from django.contrib import admin
from .models import Cliente, Empresa

class ClienteAdmin(admin.ModelAdmin):
    list_display = ('rut', 'nombres', 'apellidos', 'genero', 'fechanamiento', 'telefono', 'email', 'empresa')
    search_fields = ['rut', 'nombres']
    list_filter = ('empresa',)

class EmpresaAdmin(admin.ModelAdmin):
    list_display = ('nombre', 'ubicacion')
    search_fields = ['nombre']
    list_filter = ('ubicacion',)

# Register your models here.
admin.site.register(Cliente, ClienteAdmin)
admin.site.register(Empresa, EmpresaAdmin)
