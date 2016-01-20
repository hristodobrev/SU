using System;

public class SimpleMathExam : Exam
{
    private const int MinimalProblemsSolved = 0;
    private const int MaximalProblemsSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get { return this.problemsSolved; }
        private set
        {
            if (value < MinimalProblemsSolved)
            {
                value = MinimalProblemsSolved;
            }
            if (value > MaximalProblemsSolved)
            {
                value = MaximalProblemsSolved;
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            case 2:
                return new ExamResult(6, 2, 6, "Average result: nothing done.");
            default:
                throw new InvalidOperationException("Invalid number of problems solved.");
        }
    }
}
