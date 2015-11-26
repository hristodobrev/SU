package Problem8;

import java.io.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CSVDatabase {
    public static void main(String[] args) throws IOException {
        HashMap<String, ArrayList<String>> students = new HashMap<>();
        HashMap<String, HashMap<String, ArrayList<String>>> grades = new HashMap<>();

        String studentsDir = "src\\Problem8\\students.txt";
        String gradesDir = "src\\Problem8\\grades.txt";

        BufferedReader studentsReader = null;
        PrintWriter studentWriter = null;
        BufferedReader gradesReader = null;
        PrintWriter gradesWriter = null;

        try{
            studentsReader = new BufferedReader(new FileReader(studentsDir));
            studentWriter = new PrintWriter(new BufferedWriter(new FileWriter(studentsDir, true)));
            gradesReader = new BufferedReader(new FileReader(gradesDir));
            gradesWriter = new PrintWriter(new BufferedWriter(new FileWriter(gradesDir, true)));

            String reader;

            while ((reader = studentsReader.readLine()) != null) {
                ArrayList<String> studentIfno = new ArrayList<>();
                String[] splited = reader.split(",");
                studentIfno.add(splited[1] + " " + splited[2]);
                studentIfno.add(splited[3]);
                studentIfno.add(splited[4]);
                students.put(splited[0], studentIfno);
            }

            System.out.println("Current students in the database.");
            for (Map.Entry entry : students.entrySet()) {
                ArrayList<String> curStudent = (ArrayList<String>)entry.getValue();
                String name = curStudent.get(0);
                String age = curStudent.get(1);
                String town = curStudent.get(2);
                System.out.printf("%s (age: %s, town: %s)\n", name, age, town);
            }

            Scanner scan = new Scanner(System.in);

            String currentLine = scan.nextLine();

            if(currentLine.contains("Delete-by-id")) {
                Pattern idPat = Pattern.compile("[0-9]+");
                Matcher matcher = idPat.matcher(currentLine);
                if (matcher.find()) {
                    students.remove(matcher.group());
                }
            } else if(currentLine.contains("Insert-student")) {
                System.out.println("It does contain this shits");
                Pattern studentPat = Pattern.compile("([A-Z][a-z]+ [A-Z][a-z]+]) (\\d+) ([A-Za-z ]+)");
                Matcher matcher = studentPat.matcher(currentLine);
                if(matcher.find()){
                    System.out.println(true);
                    System.out.println(matcher.group());
                }
            }

            PrintWriter writer = new PrintWriter(studentsDir);
            writer.print("");
            writer.close();

            for(Map.Entry entry: students.entrySet()) {
                ArrayList<String> curStudent = (ArrayList<String>)entry.getValue();
                String names = curStudent.get(0);
                String[] name = names.split(" ");
                String age = curStudent.get(1);
                String town = curStudent.get(2);
                studentWriter.printf("%s,%s,%s,%s,%s)\n", entry.getKey(), name[0], name[1], age, town);
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found");
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            studentsReader.close();
            studentWriter.close();
            gradesReader.close();
            gradesWriter.close();
        }

    }
}
