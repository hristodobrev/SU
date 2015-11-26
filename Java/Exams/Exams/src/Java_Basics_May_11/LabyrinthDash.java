package Java_Basics_May_11;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class LabyrinthDash {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        Integer lines = Integer.parseInt(scan.nextLine());

        List<Character> obstacles = new ArrayList<Character>();
        obstacles.add('@');
        obstacles.add('#');
        obstacles.add('*');

        int row = 0;
        int col = 0;
        int lives = 3;

        char[][] labyrinth = new char[lines][];

        for (int i = 0; i < lines; i++) {
            String currentLine = scan.nextLine();
            labyrinth[i] = currentLine.toCharArray();
        }

        String moves = scan.nextLine();

        boolean dead = false;
        int movesCount = 0;

        for (int i = 0; i < moves.length(); i++) {
            switch(moves.charAt(i)) {
                case 'v':
                    if(row + 1 < lines && labyrinth[Math.min(lines - 1, row + 1)][col] != ' ') {
                        char curChar = labyrinth[row + 1][col];
                        if(curChar == '_' || curChar == '|') {
                            System.out.println("Bumped a wall.");
                            break;
                        } else if(curChar == '@' || curChar == '*' || curChar == '#') {
                            lives--;
                            System.out.println("Ouch! That hurt! Lives left: " + lives);
                            if(lives <= 0) {
                                System.out.println("No lives left! Game Over!");
                                dead = true;
                            }
                        } else if(curChar == '$') {
                            lives++;
                            System.out.println("Awesome! Lives left: " + lives);
                            labyrinth[row + 1][col] = '.';
                        } else {
                            System.out.println("Made a move!");
                        }
                        row++;
                    } else {
                        System.out.println("Fell off a cliff! Game Over!");
                        dead = true;
                    }
                    movesCount++;
                    break;
                case '^':
                    if(row - 1 >= 0 && labyrinth[Math.max(0, row - 1)][col] != ' ') {
                        char curChar = labyrinth[row - 1][col];
                        if(curChar == '_' || curChar == '|') {
                            System.out.println("Bumped a wall.");
                            break;
                        } else if(curChar == '@' || curChar == '*' || curChar == '#') {
                            lives--;
                            System.out.println("Ouch! That hurt! Lives left: " + lives);
                            if(lives <= 0) {
                                System.out.println("No lives left! Game Over!");
                                dead = true;
                            }
                        } else if(curChar == '$') {
                            lives++;
                            System.out.println("Awesome! Lives left: " + lives);
                            labyrinth[row - 1][col] = '.';
                        }else {
                            System.out.println("Made a move!");
                        }
                        row--;
                    } else {
                        System.out.println("Fell off a cliff! Game Over!");
                        dead = true;
                    }
                    movesCount++;
                    break;
                case '>':
                    if(col + 1 < labyrinth[row].length && labyrinth[row][Math.min(col + 1, labyrinth[row].length - 1)] != ' ') {
                        char curChar = labyrinth[row][col + 1];
                        if(curChar == '_' || curChar == '|') {
                            System.out.println("Bumped a wall.");
                            break;
                        } else if(curChar == '@' || curChar == '*' || curChar == '#') {
                            lives--;
                            System.out.println("Ouch! That hurt! Lives left: " + lives);
                            if(lives <= 0) {
                                System.out.println("No lives left! Game Over!");
                                dead = true;
                            }
                        } else if(curChar == '$') {
                            lives++;
                            System.out.println("Awesome! Lives left: " + lives);
                            labyrinth[row][col + 1] = '.';
                        }else {
                            System.out.println("Made a move!");
                        }
                        col++;
                    } else {
                        System.out.println("Fell off a cliff! Game Over!");
                        dead = true;
                    }
                    movesCount++;
                    break;
                case '<':
                    if(col - 1 >= 0 && labyrinth[row][Math.max(col - 1, 0)] != ' ') {
                        char curChar = labyrinth[row][col - 1];
                        if(curChar == '_' || curChar == '|') {
                            System.out.println("Bumped a wall.");
                            break;
                        } else if(curChar == '@' || curChar == '*' || curChar == '#') {
                            lives--;
                            System.out.println("Ouch! That hurt! Lives left: " + lives);
                            if(lives <= 0) {
                                System.out.println("No lives left! Game Over!");
                                dead = true;
                            }
                        } else if(curChar == '$') {
                            lives++;
                            System.out.println("Awesome! Lives left: " + lives);
                            labyrinth[row][col - 1] = '.';
                        }else {
                            System.out.println("Made a move!");
                        }
                        col--;
                    } else {
                        System.out.println("Fell off a cliff! Game Over!");
                        dead = true;
                    }
                    movesCount++;
                    break;
            }
            if (dead) {
                break;
            }
        }
        System.out.println("Total moves made: " + movesCount);
    }
}
