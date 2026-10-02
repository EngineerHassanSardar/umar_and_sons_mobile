// ============================================================
// Customer Ledger — PDF Export (returns base64 to C#)
// ============================================================

window.ledgerExport = {

    fmt(n) {
        return (Number(n) || 0).toLocaleString("en-US", {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        });
    },

    _loadScript(src) {
        return new Promise((resolve, reject) => {
            if (document.querySelector('script[src="' + src + '"]')) { resolve(); return; }
            const s = document.createElement("script");
            s.src = src;
            s.onload = resolve;
            s.onerror = reject;
            document.head.appendChild(s);
        });
    },

    async buildPdfBase64(customerName, customerPhone, entries, summary) {
        if (!window.jspdf) {
            await this._loadScript("https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.1/jspdf.umd.min.js");
            await this._loadScript("https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.7.1/jspdf.plugin.autotable.min.js");
        }

        const { jsPDF } = window.jspdf;
        const doc = new jsPDF({ orientation: "portrait", unit: "mm", format: "a4" });

        doc.setFontSize(13);
        doc.setFont(undefined, "bold");
        doc.text("UMAR AND SONS IMPORT AND EXPORT", 15, 15);

        doc.setFontSize(9);
        doc.setFont(undefined, "normal");
        doc.text("Alaland Road Amandara", 15, 20);

        doc.setFontSize(9);
        doc.text("Phone: 0345-2799000", 195, 15, { align: "right" });
        doc.text("Molana Javaid: 0344-2442241", 195, 19, { align: "right" });
        doc.text("Factory: 0344-2525676", 195, 23, { align: "right" });

        doc.setFontSize(16);
        doc.setFont(undefined, "bold");
        doc.text("Customer Ledger", 105, 35, { align: "center" });

        doc.setFontSize(11);
        doc.setFont(undefined, "normal");
        doc.text("Customer: " + (customerName?.name ?? customerName ?? ""), 15, 45);
        doc.text("Phone: " + (customerPhone ?? "-"), 15, 50);
        const rows = entries.map(e => [
            e.date ?? e.Date ?? "",
            e.containerNo ?? e.ContainerNo ?? "—",
            this.fmt(e.totalAmount ?? e.TotalAmount),
            this.fmt(e.paymentReceived ?? e.PaymentReceived),
            this.fmt(e.remaining ?? e.Remaining)
        ]);
        doc.autoTable({
            startY: 57,
            head: [["Date", "Container", "Total", "Paid", "Remaining"]],
            body: rows,
            theme: "grid",
            styles: { fontSize: 9, cellPadding: 2 },
            headStyles: { fillColor: [11, 18, 32], textColor: 255, fontStyle: "bold" },
            columnStyles: {
                2: { halign: "right" },
                3: { halign: "right", textColor: [4, 120, 87] },
                4: { halign: "right", textColor: [185, 28, 28] }
            }
        });

        let y = doc.lastAutoTable.finalY + 10;
        doc.setFontSize(11);
        doc.setFont(undefined, "bold");
        doc.text("Account Summary", 15, y);

        doc.setFontSize(10);
        doc.setFont(undefined, "normal");
        y += 6;
        doc.text("Opening Balance: Rs " + this.fmt(summary.openingBalance ?? summary.OpeningBalance), 15, y); y += 5;
        doc.text("Invoiced Amount: Rs " + this.fmt(summary.invoicedAmount ?? summary.InvoicedAmount), 15, y); y += 5;
        doc.text("Amount Paid: Rs " + this.fmt(summary.amountPaid ?? summary.AmountPaid), 15, y); y += 5;
        doc.setFont(undefined, "bold");
        doc.text("Amount Due: Rs " + this.fmt(summary.amountDue ?? summary.AmountDue), 15, y);
        // Return the PDF as base64 (without the data: prefix)
        const base64 = doc.output("datauristring").split(",")[1];
        return base64;
    }
};
