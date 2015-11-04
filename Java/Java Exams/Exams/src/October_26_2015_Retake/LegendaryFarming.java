package October_26_2015_Retake;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LegendaryFarming {
    public static void main(String[] args) {
        String obtainedItem = "";
        LinkedHashMap<String, Integer> materials = new LinkedHashMap<>();
        materials.put("fragments", 0);
        materials.put("motes", 0);
        materials.put("shards", 0);
        HashMap<String, Integer> junk = new HashMap<>();

        boolean foundItem = false;

        Pattern pattern = Pattern.compile("[0-9]+ [A-Za-z\\-\\_]+");

        Scanner scan = new Scanner(System.in);
        while (!foundItem) {
            String currentLine = scan.nextLine();
            Matcher matcher = pattern.matcher(currentLine);
            while (matcher.find()) {
                int count = Integer.parseInt(matcher.group().split(" ")[0]);
                String material = matcher.group().split(" ")[1].toLowerCase();

                if(material.equals("fragments") || material.equals("shards") || material.equals("motes")) {
                    if (!materials.containsKey(material)) {
                        materials.put(material, count);
                    } else {
                        int currentCount = materials.get(material);
                        materials.put(material, currentCount + count);
                    }
                } else {
                    if (!junk.containsKey(material)) {
                        junk.put(material, count);
                    } else {
                        int currentCount = junk.get(material);
                        junk.put(material, currentCount + count);
                    }
                }

                if (materials.get("shards") >= 250) {
                    obtainedItem = "Shadowmourne";
                    int currentCount = materials.get("shards");
                    materials.put("shards", currentCount - 250);
                    foundItem = true;
                    break;
                }
                if (materials.get("fragments") >= 250) {
                    obtainedItem = "Valanyr";
                    int currentCount = materials.get("fragments");
                    materials.put("fragments", currentCount - 250);
                    foundItem = true;
                    break;
                }
                if (materials.get("motes") >= 250) {
                    obtainedItem = "Dragonwrath";
                    int currentCount = materials.get("motes");
                    materials.put("motes", currentCount - 250);
                    foundItem = true;
                    break;
                }
            }
        }

        System.out.println(obtainedItem + " obtained!");
        materials.entrySet().stream()
                .sorted((k1, k2) -> k2.getValue().compareTo(k1.getValue()))
                .forEach(k -> System.out.println(k.getKey() + ": " + k.getValue()));

        List junkKeys = new ArrayList<>(junk.keySet());
        Collections.sort(junkKeys);
        for (Object junkKey : junkKeys) {
            System.out.println(junkKey + ": " + junk.get(junkKey));
        }
    }
}