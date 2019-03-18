import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Palindrome, ApiResult } from '../_models/model';
@Component({
  selector: 'app-palindrome',
  templateUrl: './palindrome.component.html'
})
@Injectable()
export class PalindromeComponent {
  public palindromes: Palindrome[];
  model: any = {};
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getPalindromes();
  }
  public addPalindrome() {

    this.http.post<ApiResult>(this.baseUrl + 'api/Palindrome/AddPalindrome', {}, { params: this.model }).subscribe(result => {
      if (result.success) {
        alert("Success");
        this.getPalindromes();
      }
        
      else
        alert(result.errorMessage);      
    }, error => {
      alert(error.message)
    });

  }
  getPalindromes() {
    
    this.http.get<ApiResult>('api/Palindrome/GetPalindromes', { }).subscribe(result => {
      if (result.success)
        this.palindromes = result.data;
    }, error => console.error(error));
    
  }
}


