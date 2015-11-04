using System;
using System.Collections.Generic;

class InitializeStudentsList
{
    public static List<Students> students = new List<Students>()
        {
            new Students("Ivan", "Ivanov", 20, 498412, "+359874983167", "i_ivanov@gmail.com", new List<int>(){3, 2, 6, 1, 4}, 2),
            new Students("Boyan", "Paunov", 26, 956814, "+359887579624", "boyan-paunov@abv.bg", new List<int>(){1, 1, 5, 6, 3}, 3),
            new Students("Georgi", "Tenev", 19, 195710, "+359295848928", "gogotenev@gmail.com", new List<int>(){4, 2, 1, 5, 5}, 1),
            new Students("Stoyan", "Tsankov", 24, 373914, "+359749845875", "stoyan-ts@mail.bg", new List<int>(){5, 2, 2, 4, 6}, 1),
            new Students("Petio", "Petkov", 27, 738711, "+35985671235", "pp-pp@mail.bg", new List<int>(){5, 3, 2, 1, 6}, 2),
            new Students("Emil", "Georgiev", 17, 387213, "+35929578624", "emo_g@abv.bg", new List<int>(){1, 1, 2, 4, 3}, 3),
            new Students("Sofia", "Marinova", 25, 628914, "+35986853415", "sofia-marinova@outlook.com", new List<int>(){1, 2, 4, 4, 5}, 1),
            new Students("Gergana", "Ilieva", 23, 671214, "+35925985157", "geri-ilieva@gmail.com", new List<int>(){5, 1, 3, 4, 4}, 2),
        };
}