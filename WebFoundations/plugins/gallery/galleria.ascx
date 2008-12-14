<%@ Control Language="C#" AutoEventWireup="true" CodeFile="galleria.ascx.cs" Inherits="Controls_gallery" %>

<asp:PlaceHolder ID="phLibrarys" runat="server">

<link href='<%=Page.ResolveClientUrl("~/static/css/galleria.css")%>' rel="stylesheet" type="text/css" media="screen"> 
<script type="text/javascript" src='<%=Page.ResolveClientUrl("~/static/javascript/jquery-1.2.6.min.js")%>'></script> 
<script type="text/javascript" src='<%=Page.ResolveClientUrl("~/static/javascript/jquery.galleria.min.js")%>'></script> 

    
</asp:PlaceHolder>
<div class="galwrapper" align="center">

    <asp:xml runat="server" id="xmlGallery" />
    <div id="main_image"></div>
    
    <div class="galnav">
    <a href="#" onclick="$.galleria.prev(); return false;">&laquo; previous</a> | <a href="#" onclick="$.galleria.next(); return false;">next &raquo;</a>
    </div>
    
    <asp:Label ID="lblMSG" runat="server" />

</div>


<script type="text/javascript"> 
			
    var options = {
		    history   : true, // activates the history object for bookmarking, back-button etc.
		    clickNext : true, // helper for making the image clickable
		    insert    : '#main_image', // the containing selector for our main image
		    onImage   : function(image,caption,thumb) { // let's add some image effects for demonstration purposes
    			
			    // fade in the image & caption
			    if(! ($.browser.mozilla && navigator.appVersion.indexOf("Win")!=-1) ) { // FF/Win fades large images terribly slow
				    image.css('display','none').fadeIn(1000);
			    }
			    caption.css('display','none').fadeIn(1000);
    			
			    // fetch the thumbnail container
			    var _li = thumb.parents('li');
    			
			    // fade out inactive thumbnail
			    _li.siblings().children('img.selected').fadeTo(500,0.3);
    			
			    // fade in active thumbnail
			    thumb.fadeTo('fast',1).addClass('selected');
    			
			    // add a title for the clickable image
			    image.attr('title','Next image >>');
		    },
		    onThumb : function(thumb) { // thumbnail effects goes here
    			
			    // fetch the thumbnail container
			    var _li = thumb.parents('li');
    			
			    // if thumbnail is active, fade all the way.
			    var _fadeTo = _li.is('.active') ? '1' : '0.3';
    			
			    // fade in the thumbnail when finnished loading
			    thumb.css({display:'none',opacity:_fadeTo}).fadeIn(1500);
    			
			    // hover effects
			    thumb.hover(
				    function() { thumb.fadeTo('fast',1); },
				    function() { _li.not('.active').children('img').fadeTo('fast',0.3); } // don't fade out if the parent is active
			    )
	    }
    };

    $('.gallery_unstyled').addClass('gallery');
    jQuery(function($) {
	    $('ul.gallery').galleria(options);
    });

</script>

<br /><br /><br />
