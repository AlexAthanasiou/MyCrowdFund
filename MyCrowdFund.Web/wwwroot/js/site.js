// create owner

$('.js-button').on('click', function()  {

    

    alert("sas");
   
    $('.js-submit-creator').attr('disabled', true);

    let firstname = $('.js-firstname').val();
    let lastname = $('.js-lastname').val();
    let email = $('.js-email').val();
    let age = parseInt($('.js-age').val());
    let photo = $('.js-photo').val();


    let data = JSON.stringify({

        firstname : firstname,// property = to let property
        lastname : lastname,
        email : email,
        age : age,
        photo : photo
        });
 
    $.ajax({
        url: '/ProjectCreator/CreateOwner',
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

$('.js-submit-backer').on('click',  () => {

    let firstname = $('.js-firstname').val();
    let lastname = $('.js-lastname').val();
    let email = $('.js-email').val();
    let age = parseInt($('.js-age').val());
    let photo = $('.js-photo').val();


    let data = JSON.stringify({

        firstname : firstname,// property = to let property
        lastname : lastname,
        email : email,
        age : age,
        photo : photo
    });

   // debugger;

    $.ajax({
        url: '/Backer/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data

    }).done((backer) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-success');
        $alertArea.html(`Successfully added backer with name ${backer.firstname}`);
        alertArea.show();
        $('js-create-backer').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();
        setTimeout(function () {
            $('.js-submit-backer').attr('disabled', false);
        }, 300);
    });

});

//// create project

//let rewards = [];


//$('.js-reward-submit').on('click', () => {


//    let tit = $('.js-reward-title').val();
//    let desc = $('.js-reward-description');
//    let price = parseFloat($('.js-reward-price').val());

//    rewards.push({

//        title: tit,
//        description: desc,
//        price: price
//    });

//});

//$('.js-project').on('click', function () {

//    let title = $('.js-title').val();
//    let description = $('.js-description').val();
//    let cost = $('.js-cost').val();
//    let category = parseInt($('.js-category').val());
//    let photo = $('.js-photo').val();
   


//    let data = JSON.stringify({

//        title = title,// property = to let property
//        description = description,
//        cost = cost,
//        category = category,
//        photo = photo,


//    });

//    $.ajax({
//        url: '/Project/Create',
//        type: 'POST',
//        contentType: 'application/json',
//        data: data
//    }).done((project) => {
//        $('.js-project-submit').hide();
//        let alertArea = $('.js-project-success');
//        $alertArea.html(`Successfully added backer with name ${backer.firstname}`);
//        $alertArea.show();
//        $('form.js-project').hide();
//    }).fail((xhr) => {
//        $('.alert').hide();
//        let $alertArea = $('.js-project-alert');
//        $alertArea.html(xhr.responseText);
//        $alertArea.fadeIn();
//        setTimeout(function () {
//            $('.js-submit-backer').attr('disabled', false);
//        }, 300);
//    });

//});