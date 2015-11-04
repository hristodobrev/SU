import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class RandomizeNumbersFromNToM {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int m = input.nextInt();
        Random rand = new Random();
        ArrayList<Integer> list = new ArrayList<>();
        for (int i = Math.min(m, n); i <= Math.max(m, n); i++) {
            list.add(i);
        }

        ArrayList<Integer> randomizedList = new ArrayList<>();

        for (int i = list.size() - 1; i >= 0; i--) {
            int currentIndex = rand.nextInt(i + 1);
            randomizedList.add(list.get(currentIndex));
            list.remove(currentIndex);
        }

        for(Integer i: randomizedList){
            System.out.print(i + " ");
        }
    }
}
