

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

console.log(monkeyPatcher.call(post, 'upvote'));

function monkeyPatcher(command) {
    if (command === 'upvote') {
        this.upvotes++;
    }

    if (command === 'downvote') {
        this.downvotes++;
    }

    if (command === 'score') {
        let totalVotes = this.upvotes + this.downvotes;
        let uv = this.upvotes;
        let dv = this.downvotes;
        if (totalVotes > 50) {
            let addNum = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);
            uv += addNum;
            dv += addNum;
        }

        let rating = 'new';
        if (uv / totalVotes > 0.66) {
            rating = 'hot';
        }

        if (dv > uv) {
            rating = 'unpopular';
        } else if (dv > 100 && uv > 100) {
            rating = 'controversial';
        }

        if (totalVotes < 10) {
            rating = 'new';
        }

        return [uv, dv, this.upvotes - this.downvotes, rating];
    }
}