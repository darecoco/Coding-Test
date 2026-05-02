#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int* solution(int numer1, int denom1, int numer2, int denom2) {
    // return 값은 malloc 등 동적 할당을 사용해주세요. 할당 길이는 상황에 맞게 변경해주세요.
    int* answer = (int*)malloc(sizeof(int) * 2);
    answer[0] = (numer1 * denom2) + (numer2 * denom1);//분자
    answer[1] = denom1 * denom2;//분모
    for(int i = answer[1]; i >= 2 ; i--){
        if(answer[0] % i == 0 && answer[1] % i == 0){
            answer[0] /= i;
            answer[1] /= i;
        }
            
    }
    return answer;
}