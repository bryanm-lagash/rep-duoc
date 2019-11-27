from django.urls import path
from .views import home, registrarse
from django.views.generic.base import RedirectView
from django.shortcuts import redirect

urlpatterns = [
    path('', home, name="home"),
    path('registrar.html/', registrarse, name="registrarse"),
]