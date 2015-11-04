import java.util.Scanner;

public class GhettoNumeralSystem {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        String string = input.nextLine();
        int length = string.length();
        String output = new String();
        for(int i = 0; i < length; i++) {
            char character = string.charAt(i);
            switch (character){
                case '0':
                    output += "Gee";
                    break;
                case '1':
                    output += "Bro";
                    break;
                case '2':
                    output += "Zuz";
                    break;
                case '3':
                    output += "Ma";
                    break;
                case '4':
                    output += "Duh";
                    break;
                case '5':
                    output += "Yo";
                    break;
                case '6':
                    output += "Dis";
                    break;
                case '7':
                    output += "Hood";
                    break;
                case '8':
                    output += "Jam";
                    break;
                case '9':
                    output += "Mack";
                    break;
            }
        }
        System.out.println(output);
    }
}
