package Problem6;

import java.io.*;

public class SaveACustomObjectInAFile {
    public static void main(String[] args) throws IOException, ClassNotFoundException {
        Course course = new Course();
        course.name = "Java Fundamentals";
        course.numerOfStudents = 943;

        ObjectOutputStream oos = new ObjectOutputStream(
                new FileOutputStream(
                        "src\\Problem6\\course.save"
                )
        );

        oos.writeObject(course);
        oos.flush();

        ObjectInputStream ois = new ObjectInputStream(
                new FileInputStream(
                        "src\\Problem6\\course.save"
                )
        );

        Object getCourse = ois.readObject();
        Course currentCourse = (Course)getCourse;
        System.out.println("Course: " + currentCourse.name + ", Students: " + currentCourse.numerOfStudents);
    }
}
