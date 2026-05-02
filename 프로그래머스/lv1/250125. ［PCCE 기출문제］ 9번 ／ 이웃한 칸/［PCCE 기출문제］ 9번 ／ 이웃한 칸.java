class Solution {
    public int solution(String[][] board, int h, int w) {
        int answer = 0;
        int[] dh = new int[] {0, 1, -1, 0}, dw = new int[] {1, 0, 0, -1};
        String color = board[h][w];
        for(int i = 0; i < dh.length; i++){
            if((h + dh[i] >= 0 && h + dh[i] <= board.length -1) && (w + dw[i] >= 0 && w + dw[i] <= board[h].length -1))
                if(color.equals(board[h + dh[i]][w + dw[i]]))
                    answer++;
        }
        return answer;
    }
}