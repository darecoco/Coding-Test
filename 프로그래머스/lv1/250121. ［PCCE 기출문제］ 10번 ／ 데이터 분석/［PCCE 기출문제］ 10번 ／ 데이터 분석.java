import java.util.Comparator;
import java.util.Arrays;

class Solution {
    //data에서 ext 값이 val_ext보다 작은 데이터만 뽑은 후, sort_by에 해당하는 값을 기준으로 오름차순으로 정렬
    public int[][] solution(int[][] data, String ext, int val_ext, String sort_by) {
        int[][] answer;
        int index = 0;
        int crit = ext_to_criterion(ext);
        int sort_crit = ext_to_criterion(sort_by);
        
        for(int i = 0; i < data.length; i++){// data에 val_ext보다 작은 데이터만 넣음
            if(data[i][crit] < val_ext){
                index++;
            }
        }
        
        answer = new int[index][];
        index = 0;
        
        for(int i = 0; i < data.length; i++){// data에 val_ext보다 작은 데이터만 넣음
            if(data[i][crit] < val_ext){
                answer[index++] = data[i];
            }
        }
        
        Arrays.sort(answer, new Comparator<int[]>() {// Comparator 클래스를 이용하여 정렬
            @Override
            public int compare(int[] o1, int[] o2) {
                return o1[sort_crit] - o2[sort_crit];
            }
        });
        
        return answer;
    }
    
    public int ext_to_criterion(String ext){
        switch (ext.charAt(0)){
            case 'c': return 0;
            case 'd' : return 1;
            case 'm': return 2;
            case 'r' : return 3;
            default: System.out.println("error");
        }
        return -1;
    }
}