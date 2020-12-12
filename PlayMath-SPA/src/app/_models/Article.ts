import { Category } from './Category';
import { User } from './User';

export interface Article {
    id: number;
    title: string;
    subTitle: string;
    category: Category;
    body: string;

    writer: User;
    writerId: string;
    writerName: string;
    published: Date;
}
