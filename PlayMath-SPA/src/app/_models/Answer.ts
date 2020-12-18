import { Question } from "./Question";
import { User } from "./User";

export interface Answer {
    answeredBy: User;
    question: Question;
    id: number;
    body: string;
    isBestAnswer: boolean;

    answerererId: string;
    questionId: number;
}
