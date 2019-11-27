from django.urls import path
from .views import home, iniciosesion, registrarse, registro,registro_usuario


urlpatterns = [
    path('', home, name="home"),
    path('inicio-sesion.html/', iniciosesion, name="inicio-sesion"),
    path('registrarse.html/', registrarse, name="registrarse"),
    path('registro.html/', registro, name="registro"),
    path('register/', registro_usuario,name='registro_usuario'),
]