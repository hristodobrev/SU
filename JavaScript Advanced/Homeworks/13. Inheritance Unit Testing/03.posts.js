function posts() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = '';
            result += `Post: ${this.title}\n`;
            result += `Content: ${this.content}`;

            return result;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this._comments = [];
        }

        addComment(comment) {
            this._comments.push(comment);
        }

        toString() {
            let result = super.toString();
            result += `\nRating: ${this.likes - this.dislikes}`;
            if (this._comments.length > 0) {
                result += '\nComments:';
                for (let comment of this._comments) {
                    result += `\n * ${comment}`;
                }
            }

            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;

            return this;
        }

        toString() {
            let result = super.toString();
            result += `\nViews: ${this.views}`;

            return result;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost
    }
}

let result = posts();
let Post = result.Post;
let SocialMediaPost = result.SocialMediaPost;
let BlogPost = result.BlogPost;

let post = new Post('Title', 'Some sample text.');
console.log(post.toString());

let socialPost = new SocialMediaPost('Social', 'This is some social post', 25, 30);
console.log(socialPost.toString());

socialPost.addComment('Awesome post!');
socialPost.addComment('I really like this post!');
console.log(socialPost.toString());

let blogPost = new BlogPost('Blog', 'This is the content of the blog', 2);
console.log(blogPost.toString());

blogPost.view().view().view();
console.log(blogPost.toString());
