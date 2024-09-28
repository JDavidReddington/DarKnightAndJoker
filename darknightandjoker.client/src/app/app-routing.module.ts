import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PaginaInicioSesionComponent } from '../Components/pagina-inicio-sesion/pagina-inicio-sesion.component';

const routes: Routes = [
  {path:'',component:PaginaInicioSesionComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
