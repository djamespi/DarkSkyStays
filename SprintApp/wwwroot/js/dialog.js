const handlers = new WeakMap();

export function attach(element, reference) {
    const dismiss = () => reference.invokeMethodAsync('Dismiss').catch(() => {});
    const cancel = event => { event.preventDefault(); dismiss(); };
    const backdrop = event => {
        const rect = element.getBoundingClientRect();
        if (event.target === element && (event.clientX < rect.left || event.clientX > rect.right || event.clientY < rect.top || event.clientY > rect.bottom)) dismiss();
    };
    const keyboard = event => {
        if (event.key !== 'Tab') return;
        const controls = [...element.querySelectorAll('button:not([disabled]), a[href], input:not([disabled]), select:not([disabled]), textarea:not([disabled]), [tabindex]:not([tabindex="-1"])')].filter(control => control.getClientRects().length > 0);
        const first = controls[0], last = controls.at(-1);
        if (!first) { event.preventDefault(); return; }
        if (event.shiftKey && document.activeElement === first) { event.preventDefault(); last.focus(); }
        else if (!event.shiftKey && document.activeElement === last) { event.preventDefault(); first.focus(); }
    };
    element.addEventListener('cancel', cancel);
    element.addEventListener('click', backdrop);
    element.addEventListener('keydown', keyboard);
    handlers.set(element, { cancel, backdrop, keyboard });
}

export function open(element) {
    if (!element.open) element.showModal();
    element.querySelector('[data-dialog-close]')?.focus({ preventScroll: true });
}

export function close(element) {
    if (element.open) element.close();
}

export function focusStep(element) {
    element.scrollTop = 0;
    const heading = element.querySelector('[data-step-title]') || element.querySelector('h2');
    if (heading) { heading.setAttribute('tabindex', '-1'); heading.focus({ preventScroll: true }); }
}

export function focusErrors(element) {
    const errors = element.querySelector('[data-validation-errors]');
    if (errors) errors.focus();
}

export function detach(element) {
    if (!element) return;
    const events = handlers.get(element);
    if (events) {
        element.removeEventListener('cancel', events.cancel);
        element.removeEventListener('click', events.backdrop);
        element.removeEventListener('keydown', events.keyboard);
        handlers.delete(element);
    }
    close(element);
}
