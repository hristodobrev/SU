class AdSingleView
{
    constructor() {
        this.html = `
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h1 class="ad-title"></h1>
                            <div class="ad-desc"></div>
                            <div class="ad-price"></div>
                            <div class="btn-group cart">
                                <button type="button" class="btn btn-success">Add to cart</button>
                            </div>
                            <div class="btn-group wishlist">
                                <button type="button" class="btn btn-danger">Add to wishlist</button>
                            </div>
                        </div>
                    </div>
                </div>
            `;
    }
}
