//Search Project

$('.js-search-submit').on('click', function () {

    let objectName = $('.js-search-input').val();

    let data = JSON.stringify({

        objectName: objectName
    });

    $.ajax({

        url: '/Home/SearchProject',
        type: 'POST',
        contentType: 'application/json',
        data: data
    });
});

// create owner

$('.js-submit-creator').on('click', function()  {

    $('.js-submit-creator').attr('disabled', true);

    let firstname = $('.js-firstname').val();
    let lastname = $('.js-lastname').val();
    let email = $('.js-email').val();
    let age = parseInt($('.js-age').val());
    let photo = $('.js-photo').val();
    let username = $('.js-username').val();
    let password = $('.js-password').val();

    let data = JSON.stringify({

        firstname : firstname,
        lastname : lastname,
        email : email,
        age : age,
        photo: photo,
        username: username,
        password: password
        });
 
    $.ajax({
        url: '/ProjectCreator/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
        
    }).done((projectCreator) => {
        
        $('.alert').hide();
        let $alertArea = $('.js-creator-success');
        $alertArea.html(`Successfully added creator with name ${projectCreator.firstname}`);
        $alertArea.show();
        $('form.js-create-creator').hide();

    }).fail((xhr) => {
        
        $('.alert').hide();
        let $alertArea = $('.js-creator-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();
        setTimeout(function () {
            $('form.js-submit-creator').attr('disabled', false);
        }, 300);
    });
});

// create backer

$('.js-submit-backer').on('click', function () {

    $('.js-submit-backer').attr('disabled', true);

    let firstname = $('.js-firstname').val();
    let lastname = $('.js-lastname').val();
    let email = $('.js-email').val();
    let age = parseInt($('.js-age').val());
    let photo = $('.js-photo').val();
    let username = $('.js-username').val();
    let password = $('.js-password').val();

    let data = JSON.stringify({

        firstname : firstname,// property = to let property
        lastname : lastname,
        email : email,
        age : age,
        photo: photo,
        username: username,
        password: password
    });

    $.ajax({
        url: '/Backer/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data

    }).done((backer) => {
        $('.alert').hide();
        let $alertArea = $('.js-backer-success');
        $alertArea.html(`Successfully added backer with name ${backer.firstname}`);
        $alertArea.show();
        $('form.js-create-backer').hide();

    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-backer-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();
        setTimeout(function () {
            $('form.js-submit-backer').attr('disabled', false);
        }, 300);
    });

});

// create project

$('.js-project-submit').on('click', function () {

    let title = $('.js-title').val();
    let description = $('.js-description').val();
    let cost = parseFloat($('.js-cost').val());
    let category = parseInt($('.js-category').val());
    let photo = $('.js-photo').val();
    let userid = parseInt($('.js-tid').val());

    let data = JSON.stringify({

        Model: {

            Title: title,
            Description: description,
            Cost: cost,
            Category: category,
            Photo: photo,
        },  
        UserId : userid                
    });  

    $.ajax({
        url: '/Project/Create',
        type: 'POST',
        contentType: 'application/json',
        data:  data

    }).done((project) => {
       $('.js-project-submit').hide();
       let alertArea = $('.js-create-project-success');
       alertArea.html(`Successfully added proj with title: ${project.title}`);
       alertArea.show();
        $('form.js-project').hide();

    }).fail((xhr) => {
       $('.alert').hide();
       let $alertArea = $('.js-create-project-alert');
       $alertArea.html(xhr.responseText);
       $alertArea.fadeIn();
       setTimeout(function () {
         $('.js-project-submit').attr('disabled', false);
       }, 300);
    });
});

// create Reward

$('.js-reward-submit').on('click', function () {

    let title = $('.js-title').val();
    let description = $('.js-desc').val();
    let price = parseFloat($('.js-price').val());
    let tempId = parseInt($('.js-tid').val());
    let creatorId = parseInt($('.js-cid').val());
 
    let data = JSON.stringify({

       title : title,
       description : description,
       price: price,
       tempId: tempId,
        creatorId: creatorId
    });

    $.ajax({
        url: '/Reward/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data

    }).done((reward) => {
        $('.js-reward-submit').hide();
        let alertArea = $('.js-create-reward-success');
        alertArea.html(`Successfully added proj with tit ${reward.title}`);
        alertArea.show();
        $('form.js-reward').hide();

    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-reward-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();
        setTimeout(function () {
            $('.js-reward-submit').attr('disabled', false);
        }, 300);
    });

});

$('.js-buy').on('click', function () {
   
    let id = parseInt($('.js-reward-id').text());

    let data = JSON.stringify({

        rewardId: id
    });

    $.ajax({
        url: '/Project/BuyProject',
        type: 'POST',
        contentType: 'application/json',
        data: data

    }).done((reward) => {
        $('.js-buy').hide();
        let alertArea = $('.js-buy-reward-success');
        alertArea.html(`Successfully bought the reward`);
        alertArea.show();
      
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-buy-reward-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();
        setTimeout(function () {
            $('.js-buy').attr('disabled', false);
        }, 300);     
    });
});





