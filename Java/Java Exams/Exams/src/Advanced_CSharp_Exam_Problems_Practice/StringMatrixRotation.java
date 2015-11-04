package Advanced_CSharp_Exam_Problems_Practice;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class StringMatrixRotation {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String rotationText = scan.nextLine();

        Pattern pattern = Pattern.compile("\\d+");
        Matcher matcher = pattern.matcher(rotationText);

        int rotation = 0;
        while (matcher.find()) {
            rotation = Integer.parseInt(matcher.group()) % 360;
        }

        ArrayList<String> matrix = new ArrayList<>();
        String nextLines = scan.nextLine();
        while (!nextLines.equals("END")) {
            matrix.add(nextLines);
            nextLines = scan.nextLine();
        }

        int cols = getCols(matrix);
        int rows = matrix.size();

        for (int row = 0; row < rows; row++) {
            if(matrix.get(row).length() < cols) {
                int fillCount = cols - matrix.get(row).length();
                String currentLine = matrix.get(row);
                for (int i = 0; i < fillCount; i++) {
                    currentLine += " ";
                }
                matrix.set(row, currentLine);
            }
        }

        ArrayList<String> rotatedMatrix = new ArrayList<>();

        if(rotation == 0) {
            rotatedMatrix = matrix;
        } else if(rotation == 90) {
            rotatedMatrix = getRotated90(matrix, rows, cols);
        } else if(rotation == 180) {
            rotatedMatrix = getRotated180(matrix, rows, cols);
        } else if(rotation == 270) {
            rotatedMatrix = getRotated270(matrix, rows, cols);
        }

        System.out.println(String.join("\n", rotatedMatrix));
    }

    private static ArrayList<String> getRotated90(ArrayList<String> matrix, int rows, int cols) {
        ArrayList<String> rotatedMatrix = new ArrayList<>();
        for (int i = 0; i < cols; i++) {
            String currentLine = "";
            for (int j = rows - 1; j >= 0; j--) {
                currentLine += matrix.get(j).charAt(i);
            }
            rotatedMatrix.add(currentLine);
        }
        return rotatedMatrix;
    }

    private static ArrayList<String> getRotated180(ArrayList<String> matrix, int rows, int cols) {
        ArrayList<String> rotatedMatrix = new ArrayList<>();
        for (int i = rows - 1; i >= 0; i--) {
            String currentLine = "";
            for (int j = cols - 1; j >= 0; j--) {
                currentLine += matrix.get(i).charAt(j);
            }
            rotatedMatrix.add(currentLine);
        }
        return rotatedMatrix;
    }

    private static ArrayList<String> getRotated270(ArrayList<String> matrix, int rows, int cols) {
        ArrayList<String> rotatedMatrix = new ArrayList<>();
        for (int i = cols - 1; i >= 0; i--) {
            String currentLine = "";
            for (int j = 0; j < rows; j++) {
                currentLine += matrix.get(j).charAt(i);
            }
            rotatedMatrix.add(currentLine);
        }
        return rotatedMatrix;
    }

    private static int getCols(ArrayList<String> matrix) {
        int maxLength = 0;
        for (int i = 0; i < matrix.size(); i++) {
            int currentLength = matrix.get(i).length();
            if(maxLength < currentLength) {
                maxLength = currentLength;
            }
        }
        return maxLength;
    }
}