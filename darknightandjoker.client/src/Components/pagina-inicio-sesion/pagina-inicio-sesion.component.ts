import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioInicioSesionFront } from '../../Models/UsuarioInicioSesionFront';
import { UsuarioService } from '../../Services/usuarioservice.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pagina-inicio-sesion',
  templateUrl: './pagina-inicio-sesion.component.html',
  styleUrls: ['./pagina-inicio-sesion.component.css']
})
export class PaginaInicioSesionComponent {
  form: FormGroup;
  isRegistering: boolean = true; // Controla el formulario visible

  constructor(
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private toastr: ToastrService
  ) {
    this.form = this.formBuilder.group({
      id: 0,
      userNameDark: ['', [Validators.required]],
      emailDark: ['', [Validators.required, Validators.pattern(/[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}/)]],
      passworDark: ['', [Validators.required, Validators.minLength(7)]]
    });
  }

  ngOnInit(): void { }

  // Alternar entre registro e inicio de sesión
  toggleForm() {
    this.isRegistering = !this.isRegistering;
    this.form.reset(); // Resetea el formulario al cambiar
  }

  guardarUsuario() {
    const usuario: UsuarioInicioSesionFront = {
      userNameDark: this.form.get('userNameDark')?.value,
      emailDark: this.form.get('emailDark')?.value,
      passworDark: this.form.get('passworDark')?.value
    };

    this.usuarioService.guardarUsuario(usuario).subscribe(data => {
      this.toastr.success('Registro Agregado', 'El usuario fue agregado');
      this.form.reset();
    });
  }

  iniciarSesion() {
    const loginData = {
      emailDark: this.form.get('emailDark')?.value,
      passworDark: this.form.get('passworDark')?.value
    };

    // Llama al servicio para iniciar sesión (necesitas implementar esta lógica)
    this.usuarioService.iniciarSesion(loginData).subscribe(
      data => {
        this.toastr.success('Inicio de sesión exitoso', 'Bienvenido');
        // Manejar la lógica después del inicio de sesión
      },
      error => {
        this.toastr.error('Error al iniciar sesión', 'Por favor verifica tus credenciales');
      }
    );
  }
}
