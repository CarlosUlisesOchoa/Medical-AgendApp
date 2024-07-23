import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { Cita, GenerarCita } from '../interfaces/cita';

@Injectable({
  providedIn: 'root',
})
export class CitasService {
  private apiUrl = 'https://www.agendapp.somee.com/api/';

  constructor(private http: HttpClient) {}

  //Obtener todas las citas
  getCitas(): Observable<Cita> {
    return this.http.get<Cita>(`${this.apiUrl}App/citas`).pipe(
      catchError((error: HttpErrorResponse) => {
        return new Observable<Cita>();
      })
    );
  }

  //Crear cita
  postCita(cita: GenerarCita): Observable<GenerarCita> {
    return this.http.post<GenerarCita>(`${this.apiUrl}App/cita`, cita).pipe(
      catchError((error: HttpErrorResponse) => {
        return new Observable<GenerarCita>();
      })
    );
  }

  //!! Funciones sin implementar

  getCitaById(id: number): Observable<GenerarCita> {
    return this.http.get<GenerarCita>(`${this.apiUrl}App/cita/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        return new Observable<GenerarCita>();
      })
    );
  }

  //Editar cita
  putCita(cita: GenerarCita): Observable<GenerarCita> {
    return this.http.put<GenerarCita>(`${this.apiUrl}App/cita`, cita).pipe(
      catchError((error: HttpErrorResponse) => {
        return new Observable<GenerarCita>();
      })
    );
  }

  //Eliminar cita
  deleteCita(id: number): Observable<GenerarCita> {
    return this.http.delete<GenerarCita>(`${this.apiUrl}App/cita/${id}`).pipe(
      catchError((error: HttpErrorResponse) => {
        return new Observable<GenerarCita>();
      })
    );
  }
}
