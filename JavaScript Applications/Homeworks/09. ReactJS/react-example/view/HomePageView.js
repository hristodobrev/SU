class HomePageView
{
    constructor() {
        this.html = `
			<div>
				<h1 id="page-title">This will be some dynamic title</h1>
				<div>
					<div id='post-list'></div>

					<div id='top-15'></div>
				</div>
			</div>`;
        return this;
    }
}
