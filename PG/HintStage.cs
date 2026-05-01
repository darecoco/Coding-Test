// https://school.programmers.co.kr/learn/courses/30/lessons/468377
// 힌트 스테이지 / Lv.1
// 가볍게 할거라 IDE키기 귀찮아서 프로그래머스에서 테스트함 + 코테 오조오억년만에 해서 4시간 30분 걸림
// 새벽 두시까지 했다. 이게 인간승리지 (코쓱
// Gemini의 도움을 받은 부분: 부분집합 공식, c#에서 우아하게 부분집합 구하는 코드


using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int solution(int[,] cost, int[,] hint) {
        int hintCnt = hint.GetLength(1); // hint 열 개수 (hint[n]의 원소개수)
        int hintStageCnt = hint.GetLength(0); // 힌트번들 개수
        int answer = 0;
        // 힌트를 전혀 쓰지 않았을 때의 비용
        for(int i = 0; i < cost.GetLength(0); i++) {
            answer += cost[i,0];
        }
        
        // 힌트권 부분집합
        var allHintCase = getAllHintCase(hintStageCnt);
        // 힌트로 인한 이득을 모두 정리한 allHintGain
        List<int> allHintGain = Enumerable.Repeat(0, allHintCase.Count).ToList();
        
        for(int hintcp = 0; hintcp < allHintCase.Count; hintcp++) {
            Dictionary<int, int> usedHints = new Dictionary<int, int>(); // <힌트권 번호, 사용된 힌트권>       
            var hintCase = allHintCase[hintcp];
            foreach(int hintn in hintCase) { // 힌트번들
                int hintnp = hintn - 1;
                allHintGain[hintcp] += hint[hintnp, 0];
                for(int i = 1; i < hintCnt; i++) { // 힌트권
                    int usedHint = hint[hintnp, i];
                    if (!usedHints.ContainsKey(usedHint)) {
                        usedHints[usedHint] = 0;
                    }
                    int usedHintCnt = usedHints[usedHint];
                    if (usedHintCnt > hintStageCnt - 1) {
                        continue;
                    }
                    
                    allHintGain[hintcp] += cost[usedHint-1,usedHintCnt+1] - cost[usedHint-1,usedHintCnt];
                    
                    usedHints[usedHint]++;
                }
            }
        }
            
        answer += allHintGain.Min();
        
        return answer;
    }
    
    // 공집합 포함 모든 부분집합(List<int>)을 가진 변수(List<List<int>>) 반환 메서드
    public List<List<int>> getAllHintCase(int hintStageCnt) {
        List<List<int>> allHintCase = new List<List<int>>();
        
        // 힌트를 구매할 모든 경우의 수
        int hintCase = 1 << hintStageCnt; // 2 ^ hintStageCnt
        int[] tempHint = new int[hintStageCnt];
        
        for(int i = 0; i < hintStageCnt; i++) {
            tempHint[i] = i + 1;
        }
        
        for (int i = 0; i < hintCase; i++)
        {
            List<int> subSet = new List<int>();
            for (int j = 0; j < hintStageCnt; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subSet.Add(tempHint[j]);
                }
            }
            allHintCase.Add(subSet);
        }
        
        return allHintCase;
    }
}
