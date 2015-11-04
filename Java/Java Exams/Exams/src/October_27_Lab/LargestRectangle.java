package October_27_Lab;

import java.util.ArrayList;
import java.util.Scanner;

public class LargestRectangle {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String currentLine = scan.nextLine();

        ArrayList<String> stringMatrix = new ArrayList<>();

        while (!currentLine.equals("END")){
            stringMatrix.add(currentLine);
            currentLine = scan.nextLine();
        }

        int rows = stringMatrix.size();
        int cols = 0;

        String[][] matrix = new String[rows][cols];

        for (int i = 0; i < stringMatrix.size(); i++) {
            matrix[i] = stringMatrix.get(i).split(",");
            cols = matrix[i].length;
        }

        int largestRectangleArea = 0;

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                rectangleExists(matrix, col, row, cols, rows);
            }
        }
        System.out.print("FOUND ONE! | [");
        System.out.printf("Row: %d; Col: %d; Width: %d; Height: %d Area: %d]\n", cellRow, cellCol,cellWidth, cellHeight, rectangleArea);
    }

    private static int cellRow = 0;
    private static int cellCol = 0;
    private static int cellWidth = 0;
    private static int cellHeight = 0;
    private static int rectangleArea = 0;

    private static void rectangleExists(String[][] matrix, int col, int row, int cols, int rows){
        String currentString = matrix[row][col];
        boolean foundRectangleStart = false;

        if (col < cols - 1 && row < rows - 1){
            if (matrix[row][col + 1].equals(currentString) && matrix[row + 1][col].equals(currentString)){
                foundRectangleStart = true;
            }
        }

        if (foundRectangleStart){
            for (int i = col + 1; i < cols; i++) {
                if (matrix[row][i].equals(currentString) && rows < row){
                    if(matrix[row + 1][i].equals(currentString)){
                        for (int j = row + 1; j < rows; j++) {
                            if(matrix[j][col].equals(currentString) && matrix[j][i].equals(currentString)){
                                if(matrix[j][col + 1].equals(currentString)){
                                    for (int k = col + 1; k <= i; k++) {
                                        System.out.println("Found one!");
                                        System.out.println(row + "," + (col - 1));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
