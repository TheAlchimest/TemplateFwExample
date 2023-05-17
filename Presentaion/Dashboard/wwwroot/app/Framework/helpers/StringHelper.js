var StringHelper = {
    capitalizeFirstLetter: function (string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    },
    lowerFirstLetter: function (string) {
        return string.charAt(0).toLowerCase() + string.slice(1);
    },

    getDomainFromUrl: function (url) {
        let domain = (new URL(url));
        return domain.hostname.replace('www.', '');
    },
    getDomainFromEmail: function (email) {
        return email.replace(/.*@/, "");
    },
    validateEmailIsRelatedToDomain: function (email, domain) {
        let helper = StringHelper;
        let emailDomain = helper.getDomainFromEmail(email).toLowerCase();
        domain = domain.toLowerCase();
        let match = email.match(/^\w+@(\w+).\w+$/);
        return (emailDomain === domain);
    }
};
