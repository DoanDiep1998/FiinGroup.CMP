//function initConsentEvents() {
//    document.body.addEventListener('click', function (e) {
//        const target = e.target;
//        if (target && target.classList.contains('consent-item')) {
//            changeConsent(target);
//        }
//    });
//}
//function acceptAll() {
//    document.querySelectorAll('.consent-item:not(:disabled)')
//        .forEach(x => x.checked = true);
//}

//function rejectAll() {
//    document.querySelectorAll('.consent-item:not(:disabled)')
//        .forEach(x => x.checked = false);
//}

//function submitConsent() {
//    const parentOrigin = new URLSearchParams(window.location.search)
//        .get('parentOrigin');
//    // Gửi lên parent
//    const consents = [];
//    document.querySelectorAll('.consent-item').forEach(el => {
//        consents.push({
//            policyCode: el.dataset.policy,
//            version: el.dataset.version,
//            accepted: el.checked
//        });
//    });
//    window.parent.postMessage(
//        {
//            type: 'CMP_CONSENT_SUBMIT',
//            consents: consents
//        },
//        parentOrigin
//    );
//}

//window.addEventListener('message', (event) => {
//    if (event.data?.type === 'CMP_PASS') {
//        const consents = [];
//        document.querySelectorAll('.consent-item').forEach(el => {
//            consents.push({
//                policyCode: el.dataset.policy,
//                version: el.dataset.version,
//                accepted: el.checked
//            });
//        });
//        saveConsentToCMP(consents, event.data.payload);
//    }
//});

//$(document).ready(function () {
//    loadPolicies();
//});

//function loadPolicies() {
//    const lang = new URLSearchParams(window.location.search).get('lang') || 'vi';
//    const productCode = '@ViewData["ProductCode"]';
//    $.ajax({
//        url: '/CMPClient/GetPolicyContent',
//        type: 'GET',
//        headers: {
//            'language': lang
//        },
//        data: { productCode: productCode },
//        success: function (data) {
//            renderPolicies(data);
//            initConsentEvents();
//        },
//        error: function () {
//            alert('Không tải được policy');
//        }
//    });
//}

//function renderPolicies(categories) {
//    const $container = $('#consentBody');
//    $container.empty();

//    $.each(categories, function (_, category) {
//        $container.append(renderCategory(category, 0));
//    });
//}

//function renderCategory(category, level) {
//    const $category = $('<div>', {
//        class: 'consent-category',
//        css: { marginLeft: level * 24 + 'px' }
//    });

//    $category.append(`
//                <h5 class="category-title">
//                    ${category.policyCategory.categoryName}
//                </h5>
//            `);

//    // ✅ policy luôn có
//    $.each(category.policyModels || [], function (_, policy) {
//        const checked = policy.isRequired ? 'checked' : '';
//        const disabled = policy.isRequired ? 'disabled' : '';

//        $category.append(`
//            <div class="consent-row">
//                <div class="consent-text">
//                    ${policy.content}
//                </div>
//                <div class="form-check form-switch">
//                    <input class="form-check-input consent-item"
//                           type="checkbox"
//                           data-policy="${policy.policyCode}"
//                           data-version="${policy.policyVersion}"
//                           ${checked}
//                           ${disabled} />
//                </div>
//            </div>
//        `);
//    });

//    // ✅ render children
//    $.each(category.children || [], function (_, childNode) {
//        $category.append(renderCategory(childNode, level + 1));
//    });

//    return $category;
//}
//function saveConsentToCMP(consents, userInfo) {
//    debugger;
//    const productCode = '@ViewData["ProductCode"]';
//    $.ajax({
//        url: '/CMPClient/SaveConsent',
//        type: 'POST',
//        contentType: 'application/json',
//        data: JSON.stringify({
//            productCode: productCode,
//            consents: consents,
//            userInfo: JSON.stringify(userInfo)
//        }),
//        success: function () {
//            alert('Consent saved');
//        }
//    });
//}