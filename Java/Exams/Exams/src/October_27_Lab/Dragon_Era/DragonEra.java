package October_27_Lab.Dragon_Era;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonEra {

    public static int dragonsCount = 0;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int dragonsStart = Integer.parseInt(scan.nextLine());

        List<Dragon> dragons = new ArrayList<>();

        for (int i = 1; i <= dragonsStart; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);

            int eggs = Integer.parseInt(scan.nextLine());
            for (int eggsCount = 0; eggsCount < eggs; eggsCount++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay();
            }

            dragons.add(dragon);
        }

        dragonsCount = dragonsStart + 1;

        int years = Integer.parseInt(scan.nextLine());
        for (int year = 1; year <= years; year++) {
            String yearType = scan.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                passAge(dragon, yearFactor);
            }
        }

        printDragons(dragons);
    }

    public static void printDragons(List<Dragon> dragons) {
        for (Dragon dragon : dragons) {
            System.out.println(dragon.getName());
            printDragons(dragon.getChildren());
        }
    }

    public static void passAge(Dragon dragon, YearType factor) {
        dragon.age();
        dragon.lay();

        if(dragon.isAlive) {
            for (Egg egg : dragon.getEggs()) {
                egg.setYearFactor(factor);

                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child : dragon.getChildren()) {
            passAge(child, factor);
        }
    }
}

enum YearType {
    Bad,
    Normal,
    Good
}

class Dragon {
    private String name;
    private int age;
    private List<Egg> eggs = new ArrayList<Egg>();
    private List<Dragon> children = new ArrayList<Dragon>();
    public boolean isAlive = true;
    private int AGE_DEATH = 6;
    private int AGE_LAY_EGGS_START = 3;
    private int AGE_LAY_EGGS_END = 4;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public List<Dragon> getChildren() {
        return children;
    }

    public void lay() {
        if(this.age >= AGE_LAY_EGGS_START
                && this.age <= AGE_LAY_EGGS_END) {
            Egg egg = new Egg(-1, this);
            this.eggs.add(egg);
        }
    }

    public void age() {
        if(this.isAlive) {
            this.age++;
        }
        if(this.age == AGE_DEATH) {
            this.isAlive = false;
        }
    }

    public void increaseOffspring(Dragon baby) {
        this.children.add(baby);
    }
}

class Egg {
    private int age;
    private Dragon parent;
    private int AGE_HATCH = 2;
    YearType yearFactor;

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void setYearFactor(YearType yearFactor) {
        this.yearFactor = yearFactor;
    }

    public void age() {
        this.age++;
    }

    public void hatch() {
        if(this.age == AGE_HATCH) {
            int yearFactor = this.yearFactor.ordinal();
            for (int i = 0; i < yearFactor; i++) {
                Dragon baby = new Dragon(
                        this.parent.getName()
                                + "/"
                                + "Dragon_"
                                + DragonEra.dragonsCount,
                        -1
                );

                this.parent.increaseOffspring(baby);
                DragonEra.dragonsCount++;
            }
        }
    }
}
