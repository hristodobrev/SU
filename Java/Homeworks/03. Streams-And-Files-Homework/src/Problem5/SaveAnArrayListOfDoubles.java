package Problem5;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

public class SaveAnArrayListOfDoubles {
    public static void main(String[] args) throws IOException, ClassNotFoundException {
        List<Double> list = new ArrayList<>();
        list.add(5.34);
        list.add(5.32);
        list.add(7.63);
        list.add(7.35);
        list.add(2.74);

        ObjectOutputStream oos = new ObjectOutputStream(
                new BufferedOutputStream(
                        new FileOutputStream(
                                "src\\Problem5\\doubles.list")));
        oos.writeObject(list);
        oos.flush();

        ObjectInputStream ois = new ObjectInputStream(
                new BufferedInputStream(
                        new FileInputStream(
                                "src\\Problem5\\doubles.list")));

        System.out.println(ois.readObject());

        oos.close();
        ois.close();
    }
}
