public class GetAverage {
    public static void main(String[] args) {
        double a = 0.005;
        double b = 0.5;
        double c = 0.55;
        double avg = getAverage(a, b, c);
        System.out.printf("%.2f", avg);
}
    public static double getAverage(double a, double b, double c){
        return (a + b + c) / 3;
    }
}
