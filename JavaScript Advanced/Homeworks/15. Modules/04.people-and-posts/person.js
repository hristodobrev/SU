class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    addToSelector(selector) {
        let dom = `<div class="person ${this.name}">
<p class="name">${this.name}</p>
<p class="age">${this.age}</p>
<div class="posts ${this.name}"></div>
</div>`;

        $(selector).append(dom);
    }
}

module.exports = Person;