jQuery(document).ready(function(){

	"use strict";

	if (jQuery.magnificPopup)
	{
		jQuery('.w-gallery-tnails-h').magnificPopup({
			type: 'image',
			delegate: 'a',
			gallery: {
				enabled: true,
				navigateByImgClick: true,
				preload: [0,1]
			},
			removalDelay: 300,
			fixedBgPos: true,
			fixedContentPos: false,
			mainClass: 'mfp-fade'

		});

		jQuery('a[ref=magnificPopup][class!=direct-link]').magnificPopup({
			type: 'image'
		});
	}

	// Carousel
	if (jQuery().carousello){
		jQuery(".w-clients.type_carousel").carousello({use3d: false});
	}

	jQuery('.contacts_form').each(function(){

		jQuery(this).find('.g-form').submit(function(){
			var form = jQuery(this),
				name, email, phone,
				nameField = form.find('input[name=name]'),
				emailField = form.find('input[name=email]'),
				phoneField = form.find('input[name=phone]'),
				message = form.find('textarea[name=message]').val(),
				errors = 0;

			if (nameField.length) {
				name = nameField.val();
			}

			if (emailField.length) {
				email = emailField.val();
			}

			if (phoneField.length) {
				phone = phoneField.val();
			}

			if (errors === 0){
				jQuery.ajax({
					type: 'POST',
					url: 'send_contact.php',
					dataType: 'json',
					data: {
						action: 'sendContact',
						name: name,
						email: email,
						phone: phone,
						message: message
					},
					success: function(data){
						if (data.success){
							jQuery.jGrowl("Message Sent!");
							if (nameField.length) {
								nameField.val('');
							}
							if (emailField.length) {
								emailField.val('');
							}
							if (phoneField.length) {
								phoneField.val('');
							}
							form.find('textarea[name=message]').val('');

						} else {
							if (data.errors.name !== '' && data.errors.name !== undefined) {
								jQuery.jGrowl(data.errors.name);
							}
							if (data.errors.email !== '' && data.errors.email !== undefined) {
								jQuery.jGrowl(data.errors.email);
							}
							if (data.errors.phone !== '' && data.errors.phone !== undefined) {
								jQuery.jGrowl(data.errors.phone);
							}
							if (data.errors.message !== '' && data.errors.message !== undefined) {
								jQuery.jGrowl(data.errors.message);
							}

							if (data.errors.sending !== '' && data.errors.sending !== undefined) {
								jQuery.jGrowl(data.errors.sending);
							}
						}
					},
					error: function(){
					}
				});
			}

			return false;
		});

	});

	if (jQuery().waypoint){
		jQuery('.w-counter').waypoint(function() {
			var counter = jQuery(this).find('.w-counter-number'),
				count = parseInt(counter.text(), 10),
				number = 0,
				step = Math.ceil(count/25),
				handler = setInterval(function() {
					number += step;
					counter.text(number);
					if (number >= count) {
						counter.text(count);
						window.clearInterval(handler);
					}
				}, 40);


		}, {offset:'85%', triggerOnce: true});
	}

	if (jQuery('.l-preloader').length)
	{
		jQuery('body').queryLoader2({
			percentage: true
		});

		jQuery(window).load(function(){
			jQuery('.l-preloader-counter').text("100%");
			jQuery('.l-preloader-bar').stop().animate({
				"height": "100%"
			}, 200);
			window.setTimeout(function(){
				jQuery('.l-preloader' ).animate({height: 0}, 300, function () {
					jQuery('.l-preloader').remove();
					jQuery('#qLimageContainer').remove();
				});
			}, 200);
		});
	}

	jQuery(window).load(function(){
		jQuery('.no-touch .l-subsection.with_parallax').each(function(){
			jQuery(this).parallax('50%', '0.3');
		});
	});


});
