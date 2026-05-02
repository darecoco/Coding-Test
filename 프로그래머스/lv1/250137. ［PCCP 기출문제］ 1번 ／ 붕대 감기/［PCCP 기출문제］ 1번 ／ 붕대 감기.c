#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

// bandage_len은 배열 bandage의 길이입니다.
// attacks_rows는 2차원 배열 attacks의 행 길이, attacks_cols는 2차원 배열 attacks의 열 길이입니다.
int solution(int bandage[], size_t bandage_len, int health, int** attacks, size_t attacks_rows, size_t attacks_cols) {
    int time = 1, succession = 0, monster_next_attack = 0;
    const int delay = bandage[0];
    const int recovery = bandage[1];
    const int plus_recovery = bandage[2];
    const int max_health = health;
    
    while(time <= attacks[attacks_rows - 1][0]){
        if(time == attacks[monster_next_attack][0]){ //몬스터의 공격이 있는가
            succession = 0; //연속 초기화
            health -= attacks[monster_next_attack][1];
            if(health <= 0) return -1; //체력 0 이하면 -1 리턴
            monster_next_attack++;
        }else{
            succession++;
            health += recovery;
            if(succession >= delay){
                health += plus_recovery;
                succession = 0;
            }
            if(health > max_health) health = max_health;
        }
        time++;
    }
    return health;
}