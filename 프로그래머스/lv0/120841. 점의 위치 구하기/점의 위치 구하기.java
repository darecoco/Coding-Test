class Solution {
    public int solution(int[] dot) {
        int answer = 0;
        answer = dot[0] < 0 ? 23 : 14;
        answer = dot[1] < 0 ? answer % 10 : answer / 10;
        return answer;
    }
}