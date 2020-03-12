import { Component, OnInit, ViewChild } from '@angular/core';
import { AutoresService } from 'src/app/services/autores.service';
import { isNull } from 'util';
import { TestBed } from '@angular/core/testing';
import { empty } from 'rxjs';
import { ErrorComponent } from 'src/app/shared/error/error.component';

export interface Nome {
  id: string;
  name: string;
}

export interface Retorno {
  result: string;
  names: Nome[];
}

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent implements OnInit {

  entrada: any[];
  erro: string;
  qtdInserir: number;
  qtdInserida: number;

  @ViewChild(ErrorComponent) errorComponent: ErrorComponent;

  constructor(private autoresService: AutoresService) { }

  ngOnInit() {

    this.entrada = [];
    this.erro = 'x';
    this.qtdInserir = 0;
    this.qtdInserida = 0;
    this.getNames();
  }

  getNames() {
    this.autoresService.getNames()
      .subscribe((result) => {
        if (JSON.stringify(result.result) === 'true') {
          this.entrada = JSON.parse(JSON.stringify(result.names));
        } else {
          this.erro = 'Erro ao buscar lista dos nomes.';
        }
      }, (result) => { this.errorComponent.setError(result.result); this.ngOnInit(); });
  }

  sendName(texto: any) {
    console.log('inserir:' + this.qtdInserir)
    console.log('inserido:' + this.qtdInserida)
    if (this.qtdInserir === 0) {
      this.errorComponent.setError('Insira seu limite de inserção.');
    } else if (String(this.qtdInserida) === String(this.qtdInserir)) {
      this.errorComponent.setError('Seu limite de inserção foi atingido.');
    } else if (texto === undefined) {
      this.errorComponent.setError('Preencha o campo nome do autor.');
    } else {
      const myObj = {
        name: texto
      };
      const myObjStr = JSON.stringify(myObj);
      console.log(myObjStr);

      this.autoresService.sendName(myObjStr)
        .subscribe((result) => {

          if (JSON.stringify(result.result) === 'true') {
            this.qtdInserida = this.qtdInserida + 1;
            this.entrada = JSON.parse(JSON.stringify(result.names));
            console.log(this.entrada.length);
          } else {
            this.erro = 'Erro ao buscar lista dos nomes.';
          }

        }, (result) => { this.errorComponent.setError(result.result); this.ngOnInit(); });

    }
  }
}
