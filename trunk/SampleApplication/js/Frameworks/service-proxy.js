
    function ServiceProxy(serviceUrl) 
    {
        var _I = this;
        this.serviceUrl = serviceUrl;

        // *** Call a wrapped object
        this.invoke = function(method, data, callback, error, bare) {
            // *** Convert input data into JSON - REQUIRES Json2.js
            var json = JSON.stringify(data);

            // *** The service endpoint URL        
            var url = _I.serviceUrl + '/' + method;

            $.ajax({
                url: url,
                data: json,
                type: "POST",
                processData: false,
                contentType: "application/json",
                timeout: 10000,
                dataType: "text",  // not "json" we'll parse
                success:
                    function(res) {
                        if (!callback) return;

                        // *** Use json library so we can fix up MS AJAX dates
                        var result = JSON.parse(res);

                        // *** Bare message IS result
                        if (bare)
                        { callback(result); return; }

                        // *** Wrapped message contains top level object node
                        // *** strip it off
                        for (var property in result) {
                            callback(result[property]);
                            break;
                        }
                    },
                error: function(xhr) {
                    if (!error) return;
                    if (xhr.responseText) {
                        var err = JSON.parse(xhr.responseText);
                        if (err)
                            error(err);
                        else
                            error({ Message: "Unknown server error." });
                    } else {
                        error({ Message: "Unknown server error." });
                    }
                    return;
                }
            });
        }

    }
