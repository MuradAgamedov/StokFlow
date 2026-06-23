/* ============================================================
   WMS Pro — Global JS
   ============================================================ */
(function () {
    'use strict';

    /* ---- Theme (Dark / Light) ---- */
    const html = document.documentElement;
    const themeBtn = document.getElementById('themeToggle');

    function setTheme(t) {
        html.setAttribute('data-bs-theme', t);
        localStorage.setItem('wmsTheme', t);
        if (themeBtn) {
            themeBtn.querySelector('i').className =
                t === 'dark' ? 'bi bi-sun-fill' : 'bi bi-moon-fill';
        }
    }
    setTheme(localStorage.getItem('wmsTheme') || 'light');
    if (themeBtn) themeBtn.addEventListener('click', function () {
        setTheme(html.getAttribute('data-bs-theme') === 'dark' ? 'light' : 'dark');
    });

    /* ---- Mobile Sidebar ---- */
    const sidebar  = document.getElementById('sidebar');
    const overlay  = document.getElementById('sbOverlay');
    const toggler  = document.getElementById('sbToggle');

    function openSb()  { sidebar.classList.add('show'); overlay.classList.add('show'); document.body.style.overflow='hidden'; }
    function closeSb() { sidebar.classList.remove('show'); overlay.classList.remove('show'); document.body.style.overflow=''; }

    if (toggler) toggler.addEventListener('click', function () { sidebar.classList.contains('show') ? closeSb() : openSb(); });
    if (overlay) overlay.addEventListener('click', closeSb);

    /* ---- Mark active sidebar link ---- */
    const path = location.pathname.toLowerCase();
    document.querySelectorAll('.sb-link').forEach(function (a) {
        const href = (a.getAttribute('href') || '').toLowerCase();
        if (href && href !== '#') {
            const cleanHref = href.replace('../', '').split('/')[0];
            if (cleanHref && path.indexOf('/' + cleanHref + '/') !== -1) {
                a.classList.add('active');
            } else if (cleanHref === 'dashboard.html' && (path.endsWith('dashboard.html') || path.endsWith('/'))) {
                a.classList.add('active');
            } else {
                a.classList.remove('active');
            }
        }
    });

    /* ---- Tooltips ---- */
    document.querySelectorAll('[data-bs-toggle="tooltip"]').forEach(function (el) {
        new bootstrap.Tooltip(el);
    });

    /* ---- Auto-dismiss alerts (6 s) ---- */
    setTimeout(function () {
        document.querySelectorAll('.alert-auto').forEach(function (el) {
            bootstrap.Alert.getOrCreateInstance(el).close();
        });
    }, 6000);

    /* ============================================================
       PURCHASE ORDER — Dynamic rows
       ============================================================ */
    var poRowIdx = 0;

    function calcRowTotal(row) {
        var q = parseFloat(row.querySelector('.po-qty')  ?.value) || 0;
        var p = parseFloat(row.querySelector('.po-price')?.value) || 0;
        var t = row.querySelector('.po-total');
        if (t) t.value = (q * p).toFixed(2);
        calcGrandTotal();
    }

    function calcGrandTotal() {
        var sum = 0;
        document.querySelectorAll('.po-total').forEach(function (el) {
            sum += parseFloat(el.value) || 0;
        });
        var gt = document.getElementById('grandTotal');
        if (gt) gt.textContent = sum.toFixed(2) + ' ₼';
    }

    function bindPoRow(row) {
        row.querySelector('.po-qty')  ?.addEventListener('input', function () { calcRowTotal(row); });
        row.querySelector('.po-price')?.addEventListener('input', function () { calcRowTotal(row); });
    }

    document.querySelectorAll('.prod-row').forEach(bindPoRow);

    var addPoRow = document.getElementById('addPoRow');
    var poContainer = document.getElementById('poContainer');

    if (addPoRow && poContainer) {
        addPoRow.addEventListener('click', function () {
            poRowIdx++;
            var idx = poRowIdx;
            var row = document.createElement('div');
            row.className = 'prod-row';
            row.id = 'pr' + idx;
            row.innerHTML = `
                <button type="button" class="btn btn-danger btn-xs rm-btn" onclick="removeRow('pr${idx}')">
                    <i class="bi bi-x"></i>
                </button>
                <div class="row g-2">
                  <div class="col-md-5">
                    <label class="form-label">Məhsul</label>
                    <div class="input-group input-group-sm">
                      <select id="poProdSelect${idx}" name="Items[${idx}].ProductId" class="form-select form-select-sm">
                        <option value="">Məhsul seçin...</option>
                        <option value="1">Laptop Dell XPS 15</option>
                        <option value="2">Printer Canon LBP236DW</option>
                        <option value="3">Monitor LG 27"</option>
                        <option value="4">Klaviatura Logitech MX Keys</option>
                        <option value="5">Siçan Logitech MX Master 3</option>
                        <option value="6">Printer Kağızı A4 (500 vərəq)</option>
                      </select>
                      <button type="button" class="btn btn-outline-secondary" onclick="triggerBarcodeScanner('poProdSelect${idx}')" title="Barkod Oxu"><i class="bi bi-qr-code-scan"></i></button>
                    </div>
                  </div>
                  <div class="col-md-2">
                    <label class="form-label">Miqdar</label>
                    <input type="number" name="Items[${idx}].Quantity" class="form-control form-control-sm po-qty" min="1" value="1">
                  </div>
                  <div class="col-md-2">
                    <label class="form-label">Vahid Qiymət (₼)</label>
                    <input type="number" name="Items[${idx}].UnitPrice" class="form-control form-control-sm po-price" step="0.01" min="0" placeholder="0.00">
                  </div>
                  <div class="col-md-3">
                    <label class="form-label">Cəmi (₼)</label>
                    <input type="text" class="form-control form-control-sm po-total" readonly placeholder="0.00">
                  </div>
                </div>
            `;
            poContainer.appendChild(row);
            bindPoRow(row);
        });
    }

    /* ============================================================
       TRANSFER — Dynamic rows
       ============================================================ */
    var trRowIdx = 0;
    var addTrRow = document.getElementById('addTrRow');
    var trContainer = document.getElementById('trContainer');

    if (addTrRow && trContainer) {
        addTrRow.addEventListener('click', function () {
            trRowIdx++;
            var idx = trRowIdx;
            var row = document.createElement('div');
            row.className = 'prod-row';
            row.id = 'tr' + idx;
            row.innerHTML = `
                <button type="button" class="btn btn-danger btn-xs rm-btn" onclick="removeRow('tr${idx}')">
                    <i class="bi bi-x"></i>
                </button>
                <div class="row g-2">
                  <div class="col-md-6">
                    <label class="form-label">Məhsul</label>
                    <div class="input-group input-group-sm">
                      <select id="transProdSelect${idx}" name="Items[${idx}].ProductId" class="form-select form-select-sm">
                        <option value="">Məhsul seçin...</option>
                        <option value="1">Laptop Dell XPS 15</option>
                        <option value="2">Printer Canon LBP236DW</option>
                        <option value="3">Monitor LG 27"</option>
                        <option value="4">Klaviatura Logitech MX Keys</option>
                      </select>
                      <button type="button" class="btn btn-outline-secondary" onclick="triggerBarcodeScanner('transProdSelect${idx}')" title="Barkod Oxu"><i class="bi bi-qr-code-scan"></i></button>
                    </div>
                  </div>
                  <div class="col-md-3">
                    <label class="form-label">Transfer Miqdarı</label>
                    <input type="number" name="Items[${idx}].Quantity" class="form-control form-control-sm" min="1" value="1">
                  </div>
                  <div class="col-md-3">
                    <label class="form-label">Mövcud Stok</label>
                    <input type="text" class="form-control form-control-sm" readonly placeholder="—" value="">
                  </div>
                </div>
            `;
            trContainer.appendChild(row);
        });
    }

    /* shared remove helper */
    window.removeRow = function (id) {
        var el = document.getElementById(id);
        if (el) { el.remove(); calcGrandTotal(); }
    };

    /* ============================================================
       ADVANCED MOCK INTERACTIVITY
       ============================================================ */
    // 1. Barcode scanner mock action
     var scanTargetInputId = null;
    window.triggerBarcodeScanner = function (targetInputId) {
        scanTargetInputId = targetInputId;
        var modalEl = document.getElementById('barcodeScanModal');
        if (modalEl) {
            var modal = bootstrap.Modal.getOrCreateInstance(modalEl);
            modal.show();
            
            // Mock scan success after 1.5s
            var statusText = document.getElementById('scanStatus');
            if (statusText) statusText.textContent = "Kamera işə salınır...";
            
            setTimeout(function () {
                if (statusText) statusText.textContent = "Barkod axtarılır...";
            }, 600);

            setTimeout(function () {
                var randomSKU = "PRD-" + ["DELL-XPS15", "CANON-LBP", "LG-27MON", "LOGI-KEYS"][Math.floor(Math.random() * 4)];
                if (scanTargetInputId) {
                    var targetInput = document.getElementById(scanTargetInputId);
                    if (targetInput) {
                        if (targetInput.tagName === 'SELECT') {
                            var mapping = {
                                "PRD-DELL-XPS15": "1",
                                "PRD-CANON-LBP": "2",
                                "PRD-LG-27MON": "3",
                                "PRD-LOGI-KEYS": "4"
                            };
                            targetInput.value = mapping[randomSKU] || "1";
                        } else {
                            targetInput.value = randomSKU;
                        }
                        // Trigger input events if listeners exist
                        targetInput.dispatchEvent(new Event('input'));
                        targetInput.dispatchEvent(new Event('change'));
                    }
                }
                if (statusText) statusText.textContent = "Oxundu: " + randomSKU;
                setTimeout(function () {
                    modal.hide();
                }, 500);
            }, 1800);
        }
    };

    // 2. Warehouse cell visualizer mock interaction
    window.selectWarehouseCell = function (cellEl, zone, shelf, sku, qty) {
        document.querySelectorAll('.wh-cell').forEach(function (c) {
            c.classList.remove('selected');
        });
        cellEl.classList.add('selected');

        var detailTitle = document.getElementById('cellDetailTitle');
        var detailBody = document.getElementById('cellDetailBody');
        if (detailTitle && detailBody) {
            detailTitle.textContent = zone + " — " + shelf;
            detailBody.innerHTML = 
                '<div class="p-2 border rounded bg-body-tertiary mb-2">' +
                '  <span class="sku d-inline-block mb-1">' + sku + '</span>' +
                '  <div class="fw-bold fs-7">Mövcud Məhsul: ' + (sku === 'PRD-DELL-XPS15' ? 'Laptop Dell XPS 15' : 'Printer Canon LBP236DW') + '</div>' +
                '  <div class="fs-8 text-muted">Mövcud Stok: <strong class="text-primary">' + qty + ' ədəd</strong></div>' +
                '</div>' +
                '<div class="fs-8 text-secondary mt-2"><i class="bi bi-info-circle me-1"></i> Bu lokasiyaya yeni məhsul yerləşdirmək üçün Stok Düzəlişi və ya Sifariş qəbulu bölməsindən istifadə edin.</div>';
        }
    };

    // 3. Auto-PO Drafting Mock Alert
    window.draftAutoPo = function () {
        alert("Sistem kritik həddəki məhsullar üçün avtomatik olaraq 'Delta Elektroniks MMC' və 'LogiLink Aksesuar LTD' şirkətlərinə yeni Draft PO layihələri hazırladı. Sifarişlər bölməsindən baxa bilərsiniz!");
    };

})();

