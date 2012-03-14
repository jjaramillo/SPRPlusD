Type.registerNamespace('SPRPlusD.UsabilityTools.TaskInbox');
SPRPlusD.UsabilityTools.TaskInbox.initialize = function () {
    var currentselectedtab = null;
    var opentrigger = $('#inbox-trigger-open');
    var closetrigger = $('#inbox-trigger-close');
    var datacontainer = $('#data-container');
    var datacontainerbackground = $('#data-container-background');
    var inboxtrigger = $('#inbox-trigger');
    var width = $(document).width() / 2;
    var tabs = $('#task-categories-tabs');
    var triggerInitialOffset = -((inboxtrigger.width() / 2) - inboxtrigger.height() / 2);

    inboxtrigger.css({ left: triggerInitialOffset });
    datacontainerbackground.css({ width: width, left: -width });
    datacontainer.css({ width: width, left: -width });
    datacontainerbackground.css({ opacity: 0.7 });
    opentrigger.click(
                    function () {
                        $(this).hide();
                        closetrigger.show();
                        datacontainerbackground.animate({ left: 0 });
                        datacontainer.animate({ left: 0 });
                        inboxtrigger.animate({ left: width + triggerInitialOffset })
                    }
                );
    closetrigger.click(
                    function () {
                        $(this).hide();
                        opentrigger.show();
                        datacontainerbackground.animate({ left: -width });
                        datacontainer.animate({ left: -width });
                        inboxtrigger.animate({ left: triggerInitialOffset });
                    }
                );
    tabs.find('a').each(function (index) {
        var currenttabtrigger = $(this);
        var targettab = $(currenttabtrigger.attr('href'));
        targettab.jScrollPane({ showArrows: true });
        currenttabtrigger.click(function () {
            targettab.show();
            if (currentselectedtab != targettab) { currentselectedtab.hide(); }
            currentselectedtab = targettab;
        });
        if (index === 0) { currentselectedtab = targettab; }
        else { targettab.hide(); }
    });
}
