import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AutoresService {

  constructor(private http: HttpClient) { }

  sendName(name: any): Observable<any> {
    
    const headers = new HttpHeaders({'Content-Type': 'application/json' });
    const url = `${environment.apiUrl}/name`;
    return this.http.post(url, name, { headers: headers });
  }

  getNames(): Observable<any> {
    
    const headers = new HttpHeaders({'Content-Type': 'application/json' });
    const url = `${environment.apiUrl}/name`;
    return this.http.get(url, { headers: headers });
  }

}
