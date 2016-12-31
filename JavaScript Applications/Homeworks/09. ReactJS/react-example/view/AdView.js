class AdView
{
    constructor() {
        this.html = `
			<div>
				<h1 id="ads-title">All Ads</h1>
                <div class="list-group" data-adsView='list'></div>
			</div>`;

        this.listItemHtml = `<a href="#" class="list-group-item list-group-item-action"></a>`;

        return this;
    }
}
