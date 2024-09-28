import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UsuarioInicioSesionFront } from '../Models/UsuarioInicioSesionFront';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  myAppUrl = 'https://localhost:7085/';  // LOCAL HOST DEL BACKEND
  myApiUrl = 'api/UsuarioRegistroInicios/'; // URL DE LA API

  constructor(private http: HttpClient) { }

  // Método para guardar un nuevo usuario
  guardarUsuario(usuario: UsuarioInicioSesionFront): Observable<UsuarioInicioSesionFront> {
    return this.http.post<UsuarioInicioSesionFront>(this.myAppUrl + this.myApiUrl, usuario);
  }

  // Método para verificar si el usuario ya existe
  iniciarSesion(loginData: { emailDark: string; passworDark: string }): Observable<any> {
    return this.http.post<any>(`${this.myAppUrl}${this.myApiUrl}iniciarSesion`, loginData);
  }
}
