/*
* Ad Controller
*/
class AdController
{
    static renderView()
    {

        return function(params)
        {
            var adView = new AdView();
            var view = $(adView.html);
            var viewListItem = $(adView.listItemHtml);

            Requester.get( 'appdata', 'books')
            .done(function (ads)
            {
                view.find('*[data-adsView]').empty();
                for(var a in ads)
                    view.find('*[data-adsView]').append( viewListItem.clone().text(ads[a].title).attr('href', 'ad?id=' + ads[a]._id) );
            });

            $('body').hide().fadeIn('slow');
            $(app.viewContainerSelector).html(view);
        }
    };

    static renderSingleView()
    {
        return function(params)
        {
            var singleView = new AdSingleView();
            var view = $(singleView.html);
            var query = JSON.stringify({ "_id": params['id'] });

            Requester.get( 'appdata', `books?query=${query}`)
            .done(function (ad)
            {
                ad = ad[0];

                view.find('.ad-title').text(ad.title);
                view.find('.ad-price').text(ad.price);
                view.find('.ad-publisher').text(ad.publisher);
                view.find('.ad-publisher').text(ad.publisher);
                view.find('.ad-description').text(ad.description);
                view.find('.ad-datePublished').text(ad.description);
            });

            $('body').hide().fadeIn('slow');
            $(app.viewContainerSelector).html(view);
        }
    }
}
