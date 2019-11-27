from django.shortcuts import render
from .forms import .CustomUserForm

# Create your views here.

def home(request):
    return render(request, 'core/home.html')

def iniciosesion(request):
    return render(request, 'core/inicio-sesion.html')

def registrarse(request):
    return render(request, 'core/registrarse.html')

def registro(request):
    return render(request, 'core/registrarse.html')

def registro_usuario(request):
    data = {
        'form':CustomUserForm()
    }
    return render {request, 'registration/register.html'}    